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
    public class ChitsController : ControllerBase
    {
        private readonly IChitRepo chitRepo;

        public ChitsController(IChitRepo chitRepo)
        {
            this.chitRepo = chitRepo;
        }



        // [Authorize(Roles = Roles.Admin)]
        // GET: api/<ChitsController>
        [HttpGet]
        // [MapToApiVersion("2.0")]
        public async Task<IEnumerable<Chit>> Get()
        {
            return await chitRepo.GetChits();
        }

        [HttpGet("{Id}")]
        public async Task<Chit> Get(int Id)
        {
            return await chitRepo.GetChitByChitId(Id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(long Id,[FromBody] Chit Chit)
        {
            await chitRepo.AddChit(Chit,Id);
            return CreatedAtAction(nameof(Get),
                         new { id = Chit.ChitId }, Chit);

        }


        // PUT api/<ChitController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int ChitId, [FromBody] int Duration)
        {
            var result = await chitRepo.UpdateChit(ChitId, Duration);
            return CreatedAtAction(nameof(Get),
                         new { id = result.ChitId}, result);
        }

        // DELETE api/<ChitController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await chitRepo.DeleteChit(Id))
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
