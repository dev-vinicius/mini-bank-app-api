using Microsoft.AspNetCore.Mvc;
using MiniBankApp.Application.UseCases.Transactions.Credit;
using MiniBankApp.Application.UseCases.Transactions.Debit;
using MiniBankApp.Communication.Requests.Transaction;

namespace MiniBankApp.Api.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult TransactionHistory(int accountId)
        {
            return Ok(new { id = accountId });
        }

        [HttpPost("transaction-credit")]
        public IActionResult TransactionCredit(int accountId, 
            [FromBody] RequestTransactionCreditJson request, 
            [FromServices] ITransactionCreditRepository repository)
        {
            var useCase = new TransactionCreditUseCase(repository);
            var result = useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }

        [HttpPost("transaction-debit")]
        public IActionResult TransactionDebit(int accountId,
            [FromBody] RequestTransactionDebitJson request,
            [FromServices] ITransactionDebitRepository repository)
        {
            var useCase = new TransactionDeditUseCase(repository);
            var result = useCase.Execute(accountId, request);
            return Created(string.Empty, result);
        }

        [HttpPost("transaction-transfer")]
        public IActionResult TransactionTransfer(int accountId)
        {
            return Ok(new { id = accountId });
        }
    }
}
