using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.Debit
{
    public interface ITransactionDebitRepository
    {
        public Account GetAccount(int accountId);

        public void SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account);
    }
}
