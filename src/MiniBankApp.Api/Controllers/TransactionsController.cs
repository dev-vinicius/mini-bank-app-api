using Microsoft.AspNetCore.Mvc;
using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;
using MiniBankApp.Communication.Requests.Transaction;
using MiniBankApp.Communication.Responses.Shared;
using MiniBankApp.Communication.Responses.Transaction;

namespace MiniBankApp.Api.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseTransactionHistoryJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TransactionHistory(int accountId,
            [FromServices] ITransactionHistoryUseCase useCase)
        {
            var result = await useCase.Execute(accountId);
            return Ok(result);
        }

        [HttpPost("transaction-credit")]
        [ProducesResponseType(typeof(ResponseTransactionCreditJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TransactionCredit(int accountId, 
            [FromBody] RequestTransactionCreditJson request, 
            [FromServices] ITransactionCreditUseCase useCase)
        {
            var result = await useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }

        [HttpPost("transaction-debit")]
        [ProducesResponseType(typeof(ResponseTransactionDebitJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TransactionDebit(int accountId,
            [FromBody] RequestTransactionDebitJson request,
            [FromServices] ITransactionDebitUseCase useCase)
        {
            var result = await useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }

        [HttpPost("transaction-transfer")]
        [ProducesResponseType(typeof(ResponseTransactionTransferJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TransactionTransfer(int accountId,
            [FromBody] RequestTransactionTransferJson request,
            [FromServices] ITransactionTransferUseCase useCase)
        {
            var result = await useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }
    }
}
