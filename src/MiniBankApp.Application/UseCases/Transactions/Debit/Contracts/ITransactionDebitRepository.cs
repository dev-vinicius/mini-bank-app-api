using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.Debit.Contracts
{
    public interface ITransactionDebitRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account);
    }
}
