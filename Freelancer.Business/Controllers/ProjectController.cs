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
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IAllocatedTimeService _timeRegistrationService;

        public ProjectController(ILogger<ProjectController> logger, IAllocatedTimeService timeRegistrationService)
        {
            _logger = logger;
            _timeRegistrationService = timeRegistrationService;
        }

        // GET api/project
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            //return new string[] { "value1", "value2" };
        }

        // GET api/project/{projectId}/allocatedTimes/
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

        // GET api/project/{userId}/allocatedTimes/{allocatedTimeId}
        [HttpGet("{userId}/allocatedTimes/{allocatedTimeId}")]
        public ActionResult<AllocatedTime> Get(int id)
        {
        }

        // GET api/project/project
        [HttpGet("timeregistrations")]
        public ActionResult<IEnumerable<string>> GetTimeRegistrations()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
