using Microsoft.AspNetCore.Mvc;
using MiniBankApp.Application.UseCases.Accounts.GetById;
using MiniBankApp.Application.UseCases.Accounts.Register;
using MiniBankApp.Communication.Requests.Account;

namespace MiniBankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Accounts(int id, 
            [FromServices] IGetAccountByIdRepository repository)
        {
            var useCase = new GetAccountByIdUseCase(repository);
            var result = useCase.Execute(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult RegisterAccount(RequestAccountRegisterJson request,
            [FromServices] IRegisterAccountRepository repository)
        {
            var useCase = new RegisterAccountUseCase(repository);
            var result = useCase.Execute(request);
            return Created(string.Empty, result);
        }
    }
}
