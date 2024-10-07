using Microsoft.EntityFrameworkCore;
using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
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
        public Task<Account?> GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
