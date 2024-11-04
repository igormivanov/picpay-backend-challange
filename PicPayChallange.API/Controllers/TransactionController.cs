using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayChallange.API.Models;
using PicPayChallange.API.Models.Dtos;
using PicPayChallange.API.Services;

namespace PicPayChallange.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {

        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService) {
            this.transactionService = transactionService;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransactionRequestDTO transaction) {

            var result = await transactionService.CreateTransaction(transaction);

            if(!result.IsSuccess) {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
