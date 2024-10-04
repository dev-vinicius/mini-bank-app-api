using Microsoft.AspNetCore.Mvc;

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
        public IActionResult TransactionCredit(int accountId)
        {
            return Ok(new { id = accountId });
        }

        [HttpPost("transaction-debit")]
        public IActionResult TransactionDebit(int accountId)
        {
            return Ok(new { id = accountId });
        }

        [HttpPost("transaction-transfer")]
        public IActionResult TransactionTransfer(int accountId)
        {
            return Ok(new { id = accountId });
        }
    }
}
