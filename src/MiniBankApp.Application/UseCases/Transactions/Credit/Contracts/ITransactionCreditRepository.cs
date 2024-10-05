using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.Credit.Contracts
{
    public interface ITransactionCreditRepository
    {
        public Account? GetAccount(int accountId);

        public void SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account);
    }
}
