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
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
