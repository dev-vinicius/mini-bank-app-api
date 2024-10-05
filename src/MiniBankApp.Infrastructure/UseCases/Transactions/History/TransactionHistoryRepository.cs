using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.UseCases.Transactions.History
{
    internal class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly MiniBankAppDbContext _context;
        public TransactionHistoryRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }

        public Account? GetAccount(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
        }

        public List<Transaction> GetTransactionsFromAccount(int accountId)
        {
            return _context.Transactions
                .Where(t => t.OriginAccountId == accountId)
                .OrderByDescending(t => t.CreateDate)
                .ToList();
        }
    }
}
