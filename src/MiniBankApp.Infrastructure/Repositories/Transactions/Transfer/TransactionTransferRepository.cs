using Microsoft.EntityFrameworkCore;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories.Transactions.Transfer
{
    internal class TransactionTransferRepository : ITransactionTransferRepository
    {
        private readonly MiniBankAppDbContext _context;
        public TransactionTransferRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetAccount(int accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account originAccount, Account destinationAccount)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await _context.Transactions.AddAsync(transaction);

                originAccount.Balance -= transaction.Value;
                originAccount.UpdateDate = DateTime.Now;
                _context.Attach(originAccount);

                destinationAccount.Balance += transaction.Value;
                destinationAccount.UpdateDate = DateTime.Now;
                _context.Attach(destinationAccount);

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
