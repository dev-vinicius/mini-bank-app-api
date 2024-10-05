using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts
{
    public interface ITransactionTransferRepository
    {
        public Account? GetAccount(int accountId);

        public void SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account originAccount, Account destinationAccount);
    }
}
