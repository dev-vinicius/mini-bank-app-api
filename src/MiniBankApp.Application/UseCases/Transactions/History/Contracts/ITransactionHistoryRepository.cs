using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.History.Contracts
{
    public interface ITransactionHistoryRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task<List<Transaction>> GetTransactionsFromAccount(int accountId);
    }
}
