using Freelancer.Business.Contracts;
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
        AllocatedTime GetAllocatedTimeById(int allocatedTimeId);
        IEnumerable<AllocatedTime> SearchAllocatedTimes(SearchAllocatedTimesRequest request);
    }
}
