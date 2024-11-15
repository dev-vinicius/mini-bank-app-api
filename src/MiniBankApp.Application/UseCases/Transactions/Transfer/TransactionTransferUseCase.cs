﻿using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Transactions;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Transfer
{
    public class TransactionTransferUseCase(
        ITransactionRepository transactionRepository,
        IAccountRepository accountRepository,
        IUnityOfWork unityOfWork,
        IEventDispatcher eventDispatcher) : ITransactionTransferUseCase
    {
        public async Task<ResponseTransactionTransferJson> Execute(int accountId,
            RequestTransactionTransferJson request)
        {
            Validate(request);

            if (accountId == request.DestinationAccountId)
                throw new ErrorOnNotFoundRecordException(
                    ResourceErrorMessages.TRANSACTION_TRANSFER_SAME_ACCOUNT_INVALID);

            var originAccount = await accountRepository.GetByIdAsync(accountId);
            var destinationAccount = await accountRepository.GetByIdAsync(request.DestinationAccountId);

            if (originAccount == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            if (destinationAccount == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            if (originAccount.Balance < request.Value)
                throw new ErrorOnTransactionException(ResourceErrorMessages.TRANSACTION_INSUFICIENT_BALANCE);

            var transaction = new Transaction
            {
                OriginAccountId = accountId,
                DestinationAccountId = request.DestinationAccountId,
                Value = request.Value,
                OperationType = Domain.Enums.OperationType.Transfer,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            await transactionRepository.SaveAsync(transaction);

            originAccount.Balance -= request.Value;
            originAccount.UpdateDate = DateTime.Now;
            await accountRepository.UpdateAsync(originAccount);
            
            destinationAccount.Balance += request.Value;
            destinationAccount.UpdateDate = DateTime.Now;
            await accountRepository.UpdateAsync(destinationAccount);
            
            await unityOfWork.CommitAsync();
            
            var transactionEvent = new TransactionEvent(transaction.Id,
                transaction.OriginAccountId,
                transaction.Value,
                transaction.OperationType,
                transaction.DestinationAccountId,
                transaction.CreateDate);
            await eventDispatcher.DispatchAsync(transactionEvent);

            return new ResponseTransactionTransferJson
            {
                TransactionId = transaction.Id,
                TransactionDate = transaction.CreateDate,
            };
        }

        private void Validate(RequestTransactionTransferJson request)
        {
            var validator = new TransactionTransferValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}