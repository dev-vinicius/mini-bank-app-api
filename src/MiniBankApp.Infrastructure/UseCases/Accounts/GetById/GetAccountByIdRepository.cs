using MiniBankApp.Application.UseCases.Accounts.GetById;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.UseCases.Accounts.GetById
{
    internal class GetAccountByIdRepository : IGetAccountByIdRepository
    {
        private readonly MiniBankAppDbContext _context;
        public GetAccountByIdRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }
        public Account? GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == id);
        }
    }
}
