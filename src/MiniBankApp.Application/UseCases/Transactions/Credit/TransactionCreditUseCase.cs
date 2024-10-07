using MiniBankApp.Application.Events;
using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
using MiniBankApp.Communication.Events.Transactions;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Credit
{
    public class TransactionCreditUseCase : ITransactionCreditUseCase
    {
        private readonly ITransactionCreditRepository _repository;
        private readonly IEventPublisher _eventPublisher;
        public TransactionCreditUseCase(ITransactionCreditRepository repository, IEventPublisher eventPublisher) 
        { 
            _repository = repository;
            _eventPublisher = eventPublisher;
        }

        public async Task<ResponseTransactionCreditJson> Execute(int accountId, RequestTransactionCreditJson request)
        {
            Validate(request);

            var account = await _repository.GetAccount(accountId);

            if (account == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            var transaction = new Transaction
            { 
                OriginAccountId = accountId,
                Value = request.Value,
                OperationType = Domain.Enums.OperationType.Credit,
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

            return new ResponseTransactionCreditJson
            {
                TransactionId = transaction.Id,
                TransactionDate = transaction.CreateDate,
            };
        }

        private void Validate(RequestTransactionCreditJson request)
        {
            var validator = new TransactionCreditValidator();
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
