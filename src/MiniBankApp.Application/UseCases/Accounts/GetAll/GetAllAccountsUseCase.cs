using MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts;
using MiniBankApp.Communication.Responses.Account;

namespace MiniBankApp.Application.UseCases.Accounts.GetAll
{
    public class GetAllAccountsUseCase : IGetAllAccountsUseCase
    {
        private readonly IGetAllAccountsRepository _repository;
        public GetAllAccountsUseCase(IGetAllAccountsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseAccountGetAllJson> Execute()
        {
            var result = new ResponseAccountGetAllJson();

            var accounts = await _repository.GetAll();

            if (accounts != null && accounts.Count > 0)
            {
                foreach (var account in accounts)
                {
                    result.Accounts.Add(new ResponseAccountGetAllItem
                    {
                        Id = account.Id,
                        Name = account.Name,
                    });
                }
            }

            return result;
        }
    }
}
