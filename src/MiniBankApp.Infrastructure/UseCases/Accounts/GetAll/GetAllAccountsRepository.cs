using Microsoft.EntityFrameworkCore;
using MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts;
using MiniBankApp.Domain.Entities;
using MiniBankApp.Infrastructure.DataAccess;

namespace MiniBankApp.Infrastructure.UseCases.Accounts.GetAll
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
