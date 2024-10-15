using Microsoft.EntityFrameworkCore;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.Repositories.Accounts.GetAll
{
    internal class GetAllAccountsRepository : IGetAllAccountsRepository
    {
        private readonly MiniBankAppDbContext _context;
        public GetAllAccountsRepository(MiniBankAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
