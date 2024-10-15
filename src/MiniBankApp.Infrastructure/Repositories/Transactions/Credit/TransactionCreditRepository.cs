using Microsoft.EntityFrameworkCore;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories.Transactions.Credit
{
    internal class TransactionCreditRepository : ITransactionCreditRepository
    {
        private readonly MiniBankAppDbContext _context;
        public TransactionCreditRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }
        public async Task<Account?> GetAccount(int accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account account)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Transactions.AddAsync(transaction);

                account.Balance += transaction.Value;
                account.UpdateDate = DateTime.Now;
                _context.Attach(account);

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                if (_context.Database.CurrentTransaction != null)
                    await _context.Database.RollbackTransactionAsync();

                throw;
            }
        }
    }
}
