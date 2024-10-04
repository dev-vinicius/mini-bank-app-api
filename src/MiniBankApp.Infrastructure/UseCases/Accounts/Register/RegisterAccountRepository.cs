using MiniBankApp.Application.UseCases.Accounts.Register;
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
        public void Save(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
