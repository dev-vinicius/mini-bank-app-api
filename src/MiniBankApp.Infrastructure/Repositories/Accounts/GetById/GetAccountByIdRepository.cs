using Microsoft.EntityFrameworkCore;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories.Accounts.GetById
{
    internal class GetAccountByIdRepository : IGetAccountByIdRepository
    {
        private readonly MiniBankAppDbContext _context;
        public GetAccountByIdRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }
        public Task<Account?> GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
