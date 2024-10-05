using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Transfer
{
    public class TransactionTransferUseCase : ITransactionTransferUseCase
    {
        private readonly ITransactionTransferRepository _repository;
        public TransactionTransferUseCase(ITransactionTransferRepository repository)
        {
            _repository = repository;
        }
        public ResponseTransactionTransferJson Execute(int accountId, RequestTransactionTransferJson request)
        {
            Validate(request);

            if (accountId == request.DestinationAccountId)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.TRANSACTION_TRANSFER_SAME_ACCOUNT_INVALID);

            var originAccount = _repository.GetAccount(accountId);
            var destinationAccount = _repository.GetAccount(request.DestinationAccountId);
            
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

            _repository.SaveTransactionAndUpdateAccountBalance(transaction, originAccount, destinationAccount);

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
