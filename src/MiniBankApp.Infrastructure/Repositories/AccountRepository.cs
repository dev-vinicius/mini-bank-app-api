using Microsoft.EntityFrameworkCore;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories;

public class AccountRepository(MiniBankAppDbContext context) : IAccountRepository
{
    public async Task<List<Account>> GetAllAsync()
    {
        return await context.Accounts.ToListAsync();
    }

    public async Task SaveAsync(Account account)
    {
        await context.Accounts.AddAsync(account);
    }

    public async Task UpdateAsync(Account account)
    {
        context.Update(account);
        await Task.FromResult(true);
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
    }
}