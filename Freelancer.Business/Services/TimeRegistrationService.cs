using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Services
{
    public class TimeRegistrationService : ITimeRegistrationService
    {
        public TimeRegistrationService()
        {
        }

        public IEnumerable<AllocatedTime> GetAllocatedTimes(int userId)
        {
            using(EFContext _context = new EFContext())
            {
                IQueryable<AllocatedTime> allocatedTimes = _context.AllocatedTimes.Where(at => at.ProjectId == projectId);
            }
        }
        public AllocatedTime GetAllocatedTimeById(int userId, int allocatedTimeId)
        {

        }
    }
}
