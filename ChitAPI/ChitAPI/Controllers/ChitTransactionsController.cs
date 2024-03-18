using ChitAPI.Models;
using ChitAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChitAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors]
    //Content negotiation
    //[Produces("application/xml")]
    [ApiController]
    public class ChitTransactionsController : ControllerBase
    {
        private readonly IChitTransactionRepo chitTransactionRepo;

        public ChitTransactionsController(IChitTransactionRepo chitTransactionRepo)
        {
            this.chitTransactionRepo = chitTransactionRepo;
        }



        // [Authorize(Roles = Roles.Admin)]
        // GET: api/<ChitTransactionsController>
        [HttpGet]
        // [MapToApiVersion("2.0")]
        public async Task<IEnumerable<ChitTransaction>> Get()
        {
            return await chitTransactionRepo.GetChitTransactions();
        }

        [HttpGet("{Id}")]
        public async Task<ChitTransaction> Get(int Id)
        {
            return await chitTransactionRepo.GetChitTransactionByChitTransactionId(Id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(long Id, [FromBody] ChitTransaction ChitTransaction)
        {
            await chitTransactionRepo.AddChitTransaction(ChitTransaction, Id);
            return CreatedAtAction(nameof(Get),
                         new { id = ChitTransaction.TransactionId }, ChitTransaction);

        }


        // PUT api/<ChitTransactionController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int ChitTransactionId, [FromBody] int Duration)
        {
            var result = await chitTransactionRepo.UpdateChitTransaction(ChitTransactionId, Duration);
            return CreatedAtAction(nameof(Get),
                         new { id = result.TransactionId }, result);
        }

        // DELETE api/<ChitController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await chitTransactionRepo.DeleteChitTransaction(Id))
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
