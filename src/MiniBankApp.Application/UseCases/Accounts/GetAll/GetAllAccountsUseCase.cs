using MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Domain.Repositories;

namespace MiniBankApp.Application.UseCases.Accounts.GetAll
{
    public class GetAllAccountsUseCase(IAccountRepository repository) : IGetAllAccountsUseCase
    {
        public async Task<ResponseAccountGetAllJson> Execute()
        {
            var result = new ResponseAccountGetAllJson();

            var accounts = await repository.GetAllAsync();

            if (accounts.Count > 0)
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
