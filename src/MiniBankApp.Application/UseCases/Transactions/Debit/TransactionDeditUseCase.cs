using MiniBankApp.Application.Events;
using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Communication.Events.Transactions;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Debit
{
    public class TransactionDeditUseCase : ITransactionDebitUseCase
    {
        private readonly ITransactionDebitRepository _repository;
        private readonly IEventPublisher _eventPublisher;
        public TransactionDeditUseCase(ITransactionDebitRepository repository, IEventPublisher eventPublisher)
        {
            _repository = repository;
            _eventPublisher = eventPublisher;
        }
        public async Task<ResponseTransactionDebitJson> Execute(int accountId, RequestTransactionDebitJson request)
        {
            Validate(request);

            var account = await _repository.GetAccount(accountId);

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

            await _repository.SaveTransactionAndUpdateAccountBalance(transaction, account);

            var transactionEvent = new TransactionEvent(transaction.Id,
                transaction.OriginAccountId,
                transaction.Value,
                (OperationType)transaction.OperationType,
                transaction.DestinationAccountId,
                transaction.CreateDate);
            await _eventPublisher.PublishAsync(transactionEvent);

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
