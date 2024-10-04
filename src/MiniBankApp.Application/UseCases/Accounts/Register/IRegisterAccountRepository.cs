using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Application.UseCases.Accounts.Register
{
    public interface IRegisterAccountRepository
    {
        public void Save(Account account);
    }
}
