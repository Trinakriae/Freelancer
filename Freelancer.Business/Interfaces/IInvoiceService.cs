using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Interfaces
{
    public interface IInvoiceService
    {
        List<int> CreateInvoices(int idUser, List<int> idAllocatedTimes);
    }
}
