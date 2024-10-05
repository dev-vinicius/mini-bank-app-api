using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
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
        public TransactionCreditUseCase(ITransactionCreditRepository repository) 
        { 
            _repository = repository;
        }

        public ResponseTransactionCreditJson Execute(int accountId, RequestTransactionCreditJson request)
        {
            Validate(request);

            var account = _repository.GetAccount(accountId);

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

            _repository.SaveTransactionAndUpdateAccountBalance(transaction, account);

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
