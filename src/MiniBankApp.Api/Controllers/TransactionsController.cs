using Microsoft.AspNetCore.Mvc;
using MiniBankApp.Application.UseCases.Transactions.Credit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Debit.Contracts;
using MiniBankApp.Application.UseCases.Transactions.History.Contracts;
using MiniBankApp.Application.UseCases.Transactions.Transfer.Contracts;
using MiniBankApp.Communication.Requests.Transaction;

namespace MiniBankApp.Api.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult TransactionHistory(int accountId,
            [FromServices] ITransactionHistoryUseCase useCase)
        {
            var result = useCase.Execute(accountId);
            return Ok(result);
        }

        [HttpPost("transaction-credit")]
        public IActionResult TransactionCredit(int accountId, 
            [FromBody] RequestTransactionCreditJson request, 
            [FromServices] ITransactionCreditUseCase useCase)
        {
            var result = useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }

        [HttpPost("transaction-debit")]
        public IActionResult TransactionDebit(int accountId,
            [FromBody] RequestTransactionDebitJson request,
            [FromServices] ITransactionDebitUseCase useCase)
        {
            var result = useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }

        [HttpPost("transaction-transfer")]
        public IActionResult TransactionTransfer(int accountId,
            [FromBody] RequestTransactionTransferJson request,
            [FromServices] ITransactionTransferUseCase useCase)
        {
            var result = useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }
    }
}
