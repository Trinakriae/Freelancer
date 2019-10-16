using Freelancer.Business.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int projectId);
        IEnumerable<AllocatedTime> GetAllocatedTimes();
        IEnumerable<AllocatedTime> GetAllocatedTimesByUserId(int userId);
        AllocatedTime GetAllocatedTimeById(int allocatedTimeId);
        dynamic SearchAllocatedTimes(int userId, DateTime? startDate, DateTime? endDate, int? customerId, bool? invoiced);
    }
}
