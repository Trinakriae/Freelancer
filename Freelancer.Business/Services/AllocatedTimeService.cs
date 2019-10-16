using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Freelancer.Business.Services
{
    public class AllocatedTimeService : IAllocatedTimeService
    {
        EFContext _context;
        ProjectService _projectService;
        public AllocatedTimeService(EFContext context, ProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AllocatedTime> GetAllocatedTimes()
        {
            IQueryable<AllocatedTime> allocatedTimes = _context.AllocatedTimes;
            return allocatedTimes.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<AllocatedTime> GetAllocatedTimesByUserId(int userId)
        {
            IQueryable<AllocatedTime> allocatedTimes = _context.AllocatedTimes.Include(at => at.pr);
                
                .Where(p => p.UserId == userId);
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

            return allocatedTime;
        }
    }
}
