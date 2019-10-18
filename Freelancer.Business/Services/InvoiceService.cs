using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel;
using OpenQA.Selenium;
using Freelancer.Business.Enums;

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

        public List<int> CreateInvoices(int idUser, List<int> idAllocatedTimes)
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

                    var allocatedTimesGroupedByCustomerList = allocatedTimes.GroupBy(at => at.Project.CustomerId).Select(atg => new {
                        customerId = atg.Key,
                        amount = atg.Sum(s => (decimal) s.EndDate.Value.Subtract(s.StartDate).TotalHours)
                    });

                    List<Invoice> newInvoiceList = new List<Invoice>();

                    foreach (var allocatedTimesGroupedByCustomer in allocatedTimesGroupedByCustomerList)
                    {
                        Invoice invoice = new Invoice();

                        invoice.CustomerId = allocatedTimesGroupedByCustomer.customerId;
                        invoice.Status = INVOICESTATUS.CREATED;
                        _context.Add(invoice);
                        newInvoiceList.Add(invoice);

                        InvoiceLine invoiceLine = new InvoiceLine {
                            Invoice = invoice,
                            Amount = allocatedTimesGroupedByCustomer.amount
                        };
                        //invoiceLine.InvoiceId = invoice.Id;
                        _context.Add(invoiceLine);
                    }
                    _context.SaveChanges();

                    transaction.Commit();

                    return newInvoiceList.Select(i => i.Id).ToList();
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
