using Microsoft.AspNetCore.Mvc;
using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Communication.Requests.Account;

namespace MiniBankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Accounts(int id,
            [FromServices] IGetAccountByIdUseCase useCase)
        {
            var result = useCase.Execute(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult RegisterAccount(RequestAccountRegisterJson request,
            [FromServices] IRegisterAccountUseCase useCase)
        {
            var result = useCase.Execute(request);
            return Created(string.Empty, result);
        }
    }
}
