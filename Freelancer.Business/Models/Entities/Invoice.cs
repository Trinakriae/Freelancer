using Freelancer.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public INVOICESTATUS Status { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<AllocatedTime> AllocatedTimes { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

    }
}
