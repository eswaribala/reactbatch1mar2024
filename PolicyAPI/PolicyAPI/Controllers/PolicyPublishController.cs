using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAPI.Repositories;
using System.Text.Json;

namespace PolicyAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors]
    [ApiController]
    public class PolicyPublishController : ControllerBase
    {
        private IPolicyPublishRepo _policyPublishRepo;
        private IPolicyRepo _policyRepo;

        private IConfiguration _configuration;


        public PolicyPublishController(IPolicyPublishRepo policyPublishRepo ,
            IConfiguration configuration, IPolicyRepo policyRepo)
        {
            _policyPublishRepo = policyPublishRepo;     
            this._configuration = configuration;
            _policyRepo = policyRepo;
        }

        [HttpPost]
        [Route("publish")]
        public async Task<IActionResult> PublishData()
        {
            var TopicName = _configuration["TopicName"];
            var data = await _policyRepo.GetAllPolicies();
            var Message=JsonSerializer.Serialize(data);
            return Ok(await _policyPublishRepo
                .PublishMessage(TopicName, Message, _configuration));


        }

    }
}
