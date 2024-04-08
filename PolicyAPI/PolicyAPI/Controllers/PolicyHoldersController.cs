using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using PolicyAPI.Auth;
using PolicyAPI.Contexts;
using PolicyAPI.Models;
using PolicyAPI.Repositories;

namespace PolicyAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class PolicyHoldersController : ControllerBase
    {
        private readonly IPolicyHolderRepo _policyHolderRepo;

        public PolicyHoldersController(IPolicyHolderRepo policyHolderRepo)
        {
           _policyHolderRepo = policyHolderRepo;
        }

        // GET: api/PolicyHolders
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IEnumerable<PolicyHolder>> GetPolicyHolders()
        {
            return await _policyHolderRepo.GetAllPolicyHolders();
        }

        // GET: api/PolicyHolders/5
        [HttpGet("{adharCardNo}")]
        public async Task<ActionResult<PolicyHolder>> GetPolicyHolder(string adharCardNo)
        {
            var policyHolder = await _policyHolderRepo.GetPolicyHolder(adharCardNo);

            if (policyHolder == null)
            {
                return NotFound();
            }

            return policyHolder;
        }

        // PUT: api/PolicyHolders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{adharCardNo}/{email}/{mobileNo}")]
        public async Task<IActionResult> PutPolicyHolder(string adharCardNo, string email,long mobileNo)
        {

            var policyHolder=await _policyHolderRepo.UpdatePolicyHolder(adharCardNo, email, mobileNo);


            return CreatedAtAction("GetPolicyHolders", new { id = policyHolder.AdharCardNo }, policyHolder);
        }

        // POST: api/PolicyHolders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyHolder>> PostPolicyHolder([FromBody] PolicyHolder policyHolder)
        {
            var result = await _policyHolderRepo.AddPolicyHolder(policyHolder);

            return CreatedAtAction("GetPolicyHolders", new { id = policyHolder.AdharCardNo }, policyHolder);
        }

        // DELETE: api/PolicyHolders/5
        [HttpDelete("{adharCardNo}")]
        public async Task<IActionResult> DeletePolicyHolder(string adharCardNo)
        {
           if(await _policyHolderRepo.DeletePolicyHolder(adharCardNo))
            {
                return new OkResult();
            }
            else
            {
                return new NoContentResult();
            }
             

         
        }

        
    }
}
