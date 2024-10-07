using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts
{
    public interface ITransactionTransferRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account originAccount, Account destinationAccount);
    }
}
