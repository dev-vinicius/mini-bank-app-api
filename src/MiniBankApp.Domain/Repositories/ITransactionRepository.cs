using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories;

public interface ITransactionRepository
{
    public Task SaveAsync(Transaction transaction);
    
    public Task<List<Transaction>> GetByAccountIdAsync(int accountId);
}