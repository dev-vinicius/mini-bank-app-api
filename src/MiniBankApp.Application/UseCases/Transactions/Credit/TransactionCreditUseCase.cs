using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Events.Contracts;
using MiniBankApp.Domain.Events.EventData.Transactions;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Transactions.Credit
{
    public class TransactionCreditUseCase(
        ITransactionRepository transactionRepository,
        IAccountRepository accountRepository,
        IUnityOfWork unityOfWork,
        IEventDispatcher eventDispatcher)
        : ITransactionCreditUseCase
    {
        public async Task<ResponseTransactionCreditJson> Execute(int accountId, RequestTransactionCreditJson request)
        {
            Validate(request);

            var account = await accountRepository.GetByIdAsync(accountId);
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
            await transactionRepository.SaveAsync(transaction);
            
            account.Balance += request.Value;
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
