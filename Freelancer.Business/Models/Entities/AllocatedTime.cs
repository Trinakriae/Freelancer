using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Models.Entities
{
    public class AllocatedTime
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Project ProjectId { get; set; }
        public virtual Invoice InvoiceId { get; set; }
    }
}
