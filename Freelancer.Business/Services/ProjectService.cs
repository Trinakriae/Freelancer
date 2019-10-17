using Freelancer.Business.Contracts;
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
        ICustomerService _customerService;
        public ProjectService(EFContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            IQueryable<Project> projects = _context.Projects.Include(p => p.User)
                                                            .Include(p => p.Customer)
                                                            .Include(p => p.AllocatedTimes);

                                                         
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
            Project project = _context.Projects.Include(p => p.User)
                                               .Include(p=> p.Customer)
                                               .Include(p => p.User)
                                               .Include(p => p.AllocatedTimes)
                                               .Where(p => p.Id == projectId).FirstOrDefault();
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
            IQueryable<AllocatedTime> allocatedTimes = _context.AllocatedTimes.Include(at => at.Project.User);
                                                                              .Include(at => at.Invoice);
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
            AllocatedTime allocatedTime = _context.AllocatedTimes.Include(at => at.Project)
                                                                 .Include(at => at.Invoice)
                                                                 .Where(p => p.Id == allocatedTimeId).FirstOrDefault();
            if (allocatedTime == null)
            {
                throw new NotFoundException();
            }
            return allocatedTime;
        }

        public IEnumerable<AllocatedTime> SearchAllocatedTimes(SearchAllocatedTimesRequest request)
        {
            IQueryable<AllocatedTime> userAllocatedTimes = _context.AllocatedTimes.Include(at => at.Project.User)
                                                                                  .Include(at => at.Project.Customer)
                                                                                  .Include(at => at.Invoice)
                                                                                  .Where(at => at.Project.User.Id == request.UserId);

            if (request.StartDate != null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => at.StartDate > request.StartDate);
            }
            if (request.EndDate != null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => at.EndDate < request.EndDate);
            }
            if (request.CustomerId != null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => at.Project.Customer.Id == request.UserId);
            }
            if (request.Invoiced != null)
            {
                userAllocatedTimes = userAllocatedTimes.Where(at => (request.Invoiced.Value && at.Invoice != null) || (!request.Invoiced.Value && at.Invoice == null));
            }
            if(userAllocatedTimes == null)
            {
                throw new NotFoundException();
            }

            return userAllocatedTimes;
        }
    }
}
