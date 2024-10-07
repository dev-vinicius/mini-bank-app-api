using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.GetById.Contracts
{
    public interface IGetAccountByIdRepository
    {
        public Task<Account?> GetAccountById(int id);
    }
}
