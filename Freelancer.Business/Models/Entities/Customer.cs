using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User UserId { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
