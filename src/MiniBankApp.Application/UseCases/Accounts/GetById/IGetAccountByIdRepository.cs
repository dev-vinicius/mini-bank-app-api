using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.GetById
{
    public interface IGetAccountByIdRepository
    {
        public Account? GetAccountById(int id);
    }
}
