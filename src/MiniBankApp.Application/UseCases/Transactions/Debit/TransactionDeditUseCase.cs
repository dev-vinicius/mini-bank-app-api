using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Debit
{
    public class TransactionDeditUseCase
    {
        private readonly ITransactionDebitRepository _repository;
        public TransactionDeditUseCase(ITransactionDebitRepository repository)
        {
            _repository = repository;
        }
        public ResponseTransactionDebitJson Execute(int accountId, RequestTransactionDebitJson request)
        {
            Validate(request);

            var account = _repository.GetAccount(accountId);

            if (account == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            if (account.Balance < request.Value)
                throw new ErrorOnTransactionException(ResourceErrorMessages.TRANSACTION_INSUFICIENT_BALANCE_FOR_DEBIT);

            var transaction = new Transaction
            {
                OriginAccountId = accountId,
                Value = request.Value,
                OperationType = Domain.Enums.OperationType.Debit,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            _repository.SaveTransactionAndUpdateAccountBalance(transaction, account);

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
