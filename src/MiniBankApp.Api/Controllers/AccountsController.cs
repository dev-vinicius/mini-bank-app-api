using Microsoft.AspNetCore.Mvc;
using MiniBankApp.Application.UseCases.Accounts.GetAll.Contracts;
using MiniBankApp.Application.UseCases.Accounts.GetById.Contracts;
using MiniBankApp.Application.UseCases.Accounts.Register.Contracts;
using MiniBankApp.Communication.Requests.Account;
using MiniBankApp.Communication.Responses.Account;
using MiniBankApp.Communication.Responses.Shared;

namespace MiniBankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAccountGetAllJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Accounts([FromServices] IGetAllAccountsUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseGetAccountByIdJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Accounts(int id,
            [FromServices] IGetAccountByIdUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseAccountRegisterJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterAccount(RequestAccountRegisterJson request,
            [FromServices] IRegisterAccountUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }
    }
}
