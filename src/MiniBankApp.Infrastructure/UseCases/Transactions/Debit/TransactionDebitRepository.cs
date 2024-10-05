using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.UseCases.Transactions.Debit
{
    public class TransactionDebitRepository : ITransactionDebitRepository
    {
        private readonly MiniBankAppDbContext _context;
        public TransactionDebitRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }
        public Account? GetAccount(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
        }

        public void SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.Transactions.Add(transaction);

                account.Balance -= transaction.Value;
                account.UpdateDate = DateTime.Now;
                _context.Attach(account);

                _context.SaveChanges();
                _context.Database.CommitTransaction();
            }
            catch (System.Exception)
            {
                if (_context.Database.CurrentTransaction != null)
                    _context.Database.RollbackTransaction();

                throw;
            }
        }
    }
}
