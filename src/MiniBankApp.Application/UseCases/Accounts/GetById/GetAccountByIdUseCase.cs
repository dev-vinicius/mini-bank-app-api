using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Exception;
using MiniBankApp.Exception.ExceptionBase;

namespace MiniBankApp.Application.UseCases.Accounts.GetById
{
    public class GetAccountByIdUseCase
    {
        private readonly IGetAccountByIdRepository _repository;
        public GetAccountByIdUseCase(IGetAccountByIdRepository repository)
        {
            _repository = repository;
        }

        public ResponseGetAccountByIdJson Execute(int id)
        {
            var account = _repository.GetAccountById(id);

            if (account == null)
                throw new ErrorOnNotFoundRecord(ResourceErrorMessages.ACCOUNT_NOT_FOUND);

            return new ResponseGetAccountByIdJson()
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
            };
        }
    }
}
