using MiniBankApp.Communication.Responses.Account;

namespace MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts
{
    public interface IGetAllAccountsUseCase
    {
        public Task<ResponseAccountGetAllJson> Execute();
    }
}
