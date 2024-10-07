using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Transactions.Credit.Contracts
{
    public interface ITransactionCreditRepository
    {
        public Task<Account?> GetAccount(int accountId);

        public Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account);
    }
}
