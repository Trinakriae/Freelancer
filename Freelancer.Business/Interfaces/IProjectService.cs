using Freelancer.Business.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Interfaces
{
    public interface IProjectService
    {
       IEnumerable<Project> GetProjects(int userId);
        Project GetProjectById(int userId, int projectId);
    }
}
