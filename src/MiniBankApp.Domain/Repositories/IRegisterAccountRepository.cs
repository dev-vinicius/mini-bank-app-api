using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Domain.Repositories
{
    public interface IRegisterAccountRepository
    {
        public Task Save(Account account);
    }
}
