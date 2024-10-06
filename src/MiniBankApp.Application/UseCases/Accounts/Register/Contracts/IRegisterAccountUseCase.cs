using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;

namespace MiniBankApp.Application.UseCases.Accounts.Register.Contracts
{
    public interface IRegisterAccountUseCase
    {
        public Task<ResponseAccountRegisterJson> Execute(RequestAccountRegisterJson request);
    }
}
