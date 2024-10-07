using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.Register.Contracts
{
    public interface IRegisterAccountRepository
    {
        public Task Save(Account account);
    }
}
