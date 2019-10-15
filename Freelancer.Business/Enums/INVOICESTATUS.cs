using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Enums
{
    public enum INVOICESTATUS : int 
    {
        CREATED = 0,
        INVOICED = 1,
        PAID = 2,
        CANCELED = 3
    }
}
