using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories.Accounts.Register
{
    internal class RegisterAccountRepository : IRegisterAccountRepository
    {
        private readonly MiniBankAppDbContext _context;
        public RegisterAccountRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }
        public async Task Save(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}
