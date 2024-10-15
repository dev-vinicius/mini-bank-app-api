using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories
{
    public interface IGetAllAccountsRepository
    {
        public Task<List<Account>> GetAll();
    }
}
