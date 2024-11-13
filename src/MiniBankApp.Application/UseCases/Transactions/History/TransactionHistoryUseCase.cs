using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Communication.Responses.Transaction;
using MiniBankApp.Exception.ExceptionBase;
using MiniBankApp.Exception;
using MiniBankApp.Domain.Repositories;

namespace MiniBankApp.Application.UseCases.Transactions.History
{
    public class TransactionHistoryUseCase(ITransactionRepository transactionRepository, 
        IAccountRepository accountRepository) : ITransactionHistoryUseCase
    {
        public async Task<ResponseTransactionHistoryJson> Execute(int accountId)
        {
            var account = await accountRepository.GetByIdAsync(accountId);

            if (account == null)
                throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            var transactions = await transactionRepository.GetByAccountIdAsync(accountId);
            var response = new ResponseTransactionHistoryJson();

            if (transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    response.Transactions.Add(new TransactionHistoryItem
                    {
                        Value = transaction.Value,
                        Date = transaction.CreateDate,
                        OperationType = (OperationType)transaction.OperationType,
                        TransferRecieved = transaction.OperationType == Domain.Enums.OperationType.Transfer && 
                                           transaction.DestinationAccountId == accountId,
                    });
                }
            }

            return response;
        }
    }
}
