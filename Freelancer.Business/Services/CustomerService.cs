using Freelancer.Business.Interfaces;
using Freelancer.Business.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
