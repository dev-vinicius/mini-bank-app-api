using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.GetById
{
    public class GetAccountByIdUseCase(IAccountRepository repository) : IGetAccountByIdUseCase
    {
        public async Task<ResponseGetAccountByIdJson> Execute(int id)
        {
            var account = await repository.GetByIdAsync(id);

            return account == null
                ? throw new ErrorOnNotFoundRecordException(ResourceErrorMessages.ACCOUNT_NOT_FOUND)
                : new ResponseGetAccountByIdJson()
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
            };
        }
    }
}
