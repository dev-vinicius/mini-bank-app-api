using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories;

public interface IAccountRepository
{
    public Task<List<Account>> GetAllAsync();
    
    public Task SaveAsync(Account account);
    
    public Task UpdateAsync(Account account);
    
    public Task<Account?> GetByIdAsync(int id);
}