using Microsoft.EntityFrameworkCore;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories;

public class TransactionRepository(MiniBankAppDbContext context) : ITransactionRepository
{
    public async Task SaveAsync(Transaction transaction)
    {
        await context.Transactions.AddAsync(transaction);
    }

    public async Task<List<Transaction>> GetByAccountIdAsync(int accountId)
    {
        return await context.Transactions
            .Where(t => t.OriginAccountId == accountId ||
                   t.OperationType == Domain.Enums.OperationType.Transfer && t.DestinationAccountId == accountId)
            .OrderByDescending(t => t.CreateDate)
            .ToListAsync();
    }
}