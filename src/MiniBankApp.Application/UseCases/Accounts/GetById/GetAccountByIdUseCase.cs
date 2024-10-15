using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Repositories;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.GetById
{
    public class GetAccountByIdUseCase : IGetAccountByIdUseCase
    {
        private readonly IGetAccountByIdRepository _repository;
        public GetAccountByIdUseCase(IGetAccountByIdRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetAccountByIdJson> Execute(int id)
        {
            var account = await _repository.GetAccountById(id);

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
