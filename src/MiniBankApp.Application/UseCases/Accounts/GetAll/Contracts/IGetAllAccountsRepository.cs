using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts
{
    public interface IGetAllAccountsRepository
    {
        public List<Account> GetAll();
    }
}
