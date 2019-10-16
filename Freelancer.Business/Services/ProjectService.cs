using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Models.Entities;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Freelancer.Business.Services
{
    public class ProjectService : IProjectService
    {
        EFContext _context;
        public ProjectService(EFContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            IQueryable<Project> projects = _context.Projects;
            if (projects == null || projects.Count() == 0)
            {
                throw new NotFoundException();
            }
            return projects.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Project GetProjectById(int projectId)
        {
            Project project = _context.Projects.Where(p => p.Id == projectId).FirstOrDefault();
            if (project == null)
            {
                throw new NotFoundException();
            }
            return project;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AllocatedTime> GetAllocatedTimes()
        {
            IQueryable<AllocatedTime> allocatedTimes = _context.AllocatedTimes;
            if (allocatedTimes == null || allocatedTimes.Count() == 0)
            {
                throw new NotFoundException();
            }
            return allocatedTimes.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<AllocatedTime> GetAllocatedTimesByUserId(int userId)
        {
            IQueryable<Project> userProjects = _context.Projects.Where(p => p.UserId == userId);
            if (userProjects == null || userProjects.Count() == 0)
            {
                throw new NotFoundException();
            }
            IQueryable<AllocatedTime> allocatedTimes = _context.AllocatedTimes.Where(at => userProjects.Any(p => p.Id == at.ProjectId));
            if (allocatedTimes == null || allocatedTimes.Count() == 0)
            {
                throw new NotFoundException();
            }
            return allocatedTimes.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allocatedTimeId"></param>
        /// <returns></returns>
        public AllocatedTime GetAllocatedTimeById(int allocatedTimeId)
        {
            AllocatedTime allocatedTime = _context.AllocatedTimes.Where(p => p.Id == allocatedTimeId).FirstOrDefault();
            if (allocatedTime == null)
            {
                throw new NotFoundException();
            }
            return allocatedTime;
        }

        public dynamic SearchAllocatedTimes(int userId, DateTime? startDate, DateTime? endDate, int? customerId, bool? invoiced)
        {
            IEnumerable<AllocatedTime> userAllocatedTimes = this.GetAllocatedTimesByUserId(userId);

            if (startDate != null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => at.StartDate > startDate);
            }
            if (endDate == null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => at.EndDate < endDate);
            }
            if (customerId == null)
            {
                IQueryable<Project> customerProjects = _context.Projects.Where(p => p.CustomerId == customerId);
                if (customerProjects == null || customerProjects.Count() == 0)
                {
                    throw new NotFoundException();
                }
                userAllocatedTimes = userAllocatedTimes.Where(at => customerProjects.Any(cp => cp.Id == at.ProjectId));
            }
            if (invoiced == null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => at.InvoiceId != null);
            }
            if(userAllocatedTimes == null)
            {
                throw new NotFoundException();
            }

            return userAllocatedTimes;
        }
    }
}
