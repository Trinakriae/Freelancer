using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel;
using OpenQA.Selenium;

namespace Freelancer.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        EFContext _context;
        IProjectService _projectService;
        public InvoiceService(EFContext context, IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }

        public void CreateInvoice(int idUser, List<int> idAllocatedTimes)
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    IEnumerable<AllocatedTime> allocatedTimes = _projectService.GetAllocatedTimes().Where(at => at.Project.User.Id == idUser && idAllocatedTimes.Any(idt => idt == at.Id));
                    if(allocatedTimes == null)
                    {
                        throw new NotFoundException();
                    }
                    if(allocatedTimes.Any(at => at.Invoice != null) || allocatedTimes.Any(at => at.EndDate == null))
                    { 
                        throw new Exception("In the allocated times set to be invoiced there are invalid items");
                    }

                    allocatedTimes.GroupBy(at => at.Project.CustomerId).Select(atg => new {
                        customerId = atg.Key,
                        x = atg.Sum(s => s.EndDate.Value.Subtract(s.StartDate).TotalHours)
                    });
                    


                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
