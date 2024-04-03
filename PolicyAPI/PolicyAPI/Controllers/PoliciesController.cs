using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolicyAPI.Contexts;
using PolicyAPI.Models;
using PolicyAPI.Repositories;

namespace PolicyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepo _policyRepo;

        public PoliciesController(IPolicyRepo policyRepo)
        {
            _policyRepo = policyRepo;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return await _policyRepo.GetAllPolicies();
        }

        // GET: api/Policies/5
        [HttpGet("{policyNo}")]
        public async Task<ActionResult<Policy>> GetPolicy(long policyNo)
        {
            var policy = await _policyRepo.GetPolicyByPolicyNo(policyNo);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

       

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{adharCardNo}/{registrationNo}")]
        public async Task<ActionResult<Policy>> PostPolicy([FromBody] Policy policy, 
            string adharCardNo, string registrationNo)
        {
            var result = await _policyRepo.AddPolicy(policy,adharCardNo,registrationNo);

            return CreatedAtAction("GetPolicies", new { id = policy.PolicyNo }, policy);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{policyNo}")]
        public async Task<IActionResult> DeletePolicy(long policyNo)
        {
            if(await _policyRepo.DeletePolicy(policyNo))
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }

     
    }
}
