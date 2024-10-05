using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.History.Contracts
{
    public interface ITransactionHistoryRepository
    {
        public Account? GetAccount(int accountId);

        public List<Transaction> GetTransactionsFromAccount(int accountId);
    }
}
