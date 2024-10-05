using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.GetById.Contracts
{
    public interface IGetAccountByIdRepository
    {
        public Account? GetAccountById(int id);
    }
}
