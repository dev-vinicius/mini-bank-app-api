using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories
{
    public interface ITransactionDebitRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account);
    }
}
