using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.UseCases.Accounts.Register
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
