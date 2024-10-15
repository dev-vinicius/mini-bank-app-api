using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories
{
    public interface ITransactionHistoryRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task<List<Transaction>> GetTransactionsFromAccount(int accountId);
    }
}
