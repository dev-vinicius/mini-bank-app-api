using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories
{
    public interface IGetAccountByIdRepository
    {
        public Task<Account?> GetAccountById(int id);
    }
}
