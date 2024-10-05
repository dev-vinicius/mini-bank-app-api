using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.UseCases.Transactions.Transfer
{
    internal class TransactionTransferRepository : ITransactionTransferRepository
    {
        private readonly MiniBankAppDbContext _context;
        public TransactionTransferRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }

        public Account? GetAccount(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
        }

        public void SaveTransactionAndUpdateAccountBalance(Transaction transaction, Account originAccount, Account destinationAccount)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.Transactions.Add(transaction);

                originAccount.Balance -= transaction.Value;
                originAccount.UpdateDate = DateTime.Now;
                _context.Attach(originAccount);

                destinationAccount.Balance += transaction.Value;
                destinationAccount.UpdateDate = DateTime.Now;
                _context.Attach(destinationAccount);

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
