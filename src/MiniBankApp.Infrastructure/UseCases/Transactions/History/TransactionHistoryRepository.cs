using Microsoft.EntityFrameworkCore;
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

        public async Task<Account?> GetAccount(int accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task<List<Transaction>> GetTransactionsFromAccount(int accountId)
        {
            return await _context.Transactions
                .Where(t => t.OriginAccountId == accountId || 
                        (t.OperationType == Domain.Enums.OperationType.Transfer && t.DestinationAccountId == accountId))
                .OrderByDescending(t => t.CreateDate)
                .ToListAsync();
        }
    }
}
