using Freelancer.Business.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Interfaces
{
    public interface IAllocatedTimeService
    {
       IEnumerable<AllocatedTime> GetAllocatedTimes(int userId);
        AllocatedTime GetAllocatedTimeById(int userId, int allocatedTimeId);
    }
}
