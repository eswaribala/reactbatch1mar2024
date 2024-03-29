using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAPI.Repositories;

namespace PolicyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyHoldersController : ControllerBase
    {
        private IPolicyHolderRepo _policyHolderRepo;

        public PolicyHoldersController(IPolicyHolderRepo policyHolderRepo)
        {
            _policyHolderRepo = policyHolderRepo;
        } 

    }
}
