﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Business.Interfaces;
using Freelancer.Business.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Freelancer.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        // GET api/project
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            try
            {
                IEnumerable<Project> projects = _projectService.GetProjects();
                return Ok(projects);
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/project/{projectId}
        [HttpGet("{projectId}")]
        public ActionResult<IEnumerable<Project>> GetProjectById([FromRoute] int projectId)
        {
            try
            {
                Project project = _projectService.GetProjectById(projectId);
                return Ok(project);
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/project/user/{userId}
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Project>> GetProjectByUserId([FromRoute] int userId)
        {
            try
            {
                IEnumerable<Project> userProjects = _projectService.GetProjects().Where(p => p.UserId == userId);
                return Ok(userProjects);
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/project/allocatedTimes/
        [HttpGet("allocatedTimes")]
        public ActionResult<IEnumerable<AllocatedTime>> GetAllocatedTimes()
        {
            try
            {
                IEnumerable<AllocatedTime> allocatedTimes = _projectService.GetAllocatedTimes();
                return Ok(allocatedTimes);
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/project/user/{userId}/allocatedTimes/
        [HttpGet("user/{userId}/allocatedTimes")]
        public ActionResult<IEnumerable<AllocatedTime>> GetAllocatedTimesByProjectId([FromRoute] int userId)
        {
            try
            {
                IEnumerable<AllocatedTime> allocatedTimes = _projectService.GetAllocatedTimesByUserId(userId);
                return Ok(allocatedTimes);
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/project/user/{userId}/allocatedTimes/search
        [HttpGet("user/{userId}/allocatedTimes/search")]
        public ActionResult SearchAllocatedTimes([FromRoute] int userId, DateTime? startDate, DateTime? endDate, int? customerId, bool? invoiced)
        {
            try
            {
               

                return Ok(allocatedTimes);
            }
            catch (NotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error Occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
