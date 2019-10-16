using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return projects.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Project> GetProjectsByUserId(int userId)
        {
            IQueryable<Project> projects = _context.Projects.Where(p => p.UserId == userId);
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

            return project;
        }
    }
}
