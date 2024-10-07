using MiniBankApp.Communication.Responses.Account;

namespace MiniBankApp.Application.UseCases.Accounts.GetById.Contracts
{
    public interface IGetAccountByIdUseCase
    {
        public Task<ResponseGetAccountByIdJson> Execute(int id);
    }
}
