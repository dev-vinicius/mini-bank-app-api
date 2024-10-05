using MiniBankApp.Communication.Responses.Account;

namespace MiniBankApp.Application.UseCases.Accounts.GetById.Contracts
{
    public interface IGetAccountByIdUseCase
    {
        public ResponseGetAccountByIdJson Execute(int id);
    }
}
