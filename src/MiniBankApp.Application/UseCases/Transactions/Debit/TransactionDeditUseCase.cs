using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Transactions;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Debit
{
    public class TransactionDeditUseCase(
        ITransactionRepository transactionRepository,
        IAccountRepository accountRepository,
        IUnityOfWork unityOfWork,
        IEventDispatcher eventDispatcher)
        : ITransactionDebitUseCase
    {
        public async Task<ResponseTransactionDebitJson> Execute(int accountId, RequestTransactionDebitJson request)
        {
            Validate(request);

            var account = await accountRepository.GetByIdAsync(accountId);

            if (account == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            if (account.Balance < request.Value)
                throw new ErrorOnTransactionException(ResourceErrorMessages.TRANSACTION_INSUFICIENT_BALANCE);

            var transaction = new Transaction
            {
                OriginAccountId = accountId,
                Value = request.Value,
                OperationType = Domain.Enums.OperationType.Debit,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            await transactionRepository.SaveAsync(transaction);
            
            account.Balance -= request.Value;
            account.UpdateDate = DateTime.Now;
            await accountRepository.UpdateAsync(account);
            
            await unityOfWork.CommitAsync();

            var transactionEvent = new TransactionEvent(transaction.Id,
                transaction.OriginAccountId,
                transaction.Value,
                transaction.OperationType,
                transaction.DestinationAccountId,
                transaction.CreateDate);
            await eventDispatcher.DispatchAsync(transactionEvent);

            return new ResponseTransactionDebitJson
            {
                TransactionId = transaction.Id,
                TransactionDate = transaction.CreateDate,
            };
        }

        private void Validate(RequestTransactionDebitJson request)
        {
            var validator = new TransactionDebitValidator();
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
