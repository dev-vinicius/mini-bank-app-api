using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories
{
    public interface ITransactionTransferRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account originAccount, Account destinationAccount);
    }
}
