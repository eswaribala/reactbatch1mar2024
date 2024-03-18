using ChitAPI.Models;
using ChitAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
    
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo customerRepo;

        public CustomersController(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }



       // [Authorize(Roles = Roles.Admin)]
        // GET: api/<CustomersController>
        [HttpGet]
        // [MapToApiVersion("2.0")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customerRepo.GetCustomers();
        }

        [HttpGet("{Id}")]
        public async Task<Customer> Get(int Id)
        {
            return await customerRepo.GetCustomerById(Id);
        }

        [HttpGet("{Email}/{Password}")]
        public async Task<Customer> Get(String Email, String Password)
        {
            return await customerRepo.LoginValidation(Email, Password);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer Customer)
        {
            await customerRepo.AddCustomer(Customer);
            return CreatedAtAction(nameof(Get),
                         new { id = Customer.Id }, Customer);

        }


        // PUT api/<CustomersController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] long Phone)
        {
            var result = await customerRepo.UpdateCustomer(Id, Phone);
            return CreatedAtAction(nameof(Get),
                         new { id = result.Id }, result);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await customerRepo.DeleteCustomer(Id))
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}
