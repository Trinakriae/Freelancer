using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Models.Entities
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual User UserId { get; set; }
        public virtual Customer CustomerId { get; set; }
        public virtual ICollection<AllocatedTime> AllocatedTimes { get; set; }
    }
}
