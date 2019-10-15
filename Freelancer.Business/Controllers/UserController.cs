using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Business.Interfaces;
using Freelancer.Business.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Freelancer.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ITimeRegistrationService _timeRegistrationService;

        public UserController(ILogger<UserController> logger, ITimeRegistrationService timeRegistrationService)
        {
            _logger = logger;
            _timeRegistrationService = timeRegistrationService;
        }

        // GET api/user/{userId}/allocatedTimes/
        [HttpGet("{userId}/allocatedTimes")]
        public ActionResult<IEnumerable<AllocatedTime>> GetAllocatedTimes(int userId)
        {
            try
            {
                IEnumerable<AllocatedTime> allocatedTimes = _timeRegistrationService.GetAllocatedTimes(userId);
            }
            catch(Exception ex)
            {
                //log and throw
            }
           
            
        }

        // GET api/user/{userId}/allocatedTimes/{allocatedTimeId}
        [HttpGet("{userId}/allocatedTimes/{allocatedTimeId}")]
        public ActionResult<AllocatedTime> Get(int id)
        {
        }

        // GET api/user/project
        [HttpGet("timeregistrations")]
        public ActionResult<IEnumerable<string>> GetTimeRegistrations()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("timeregistrations/{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
