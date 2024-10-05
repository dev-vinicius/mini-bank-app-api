using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.Register.Contracts
{
    public interface IRegisterAccountRepository
    {
        public void Save(Account account);
    }
}
