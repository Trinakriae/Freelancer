using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Interfaces
{
    public interface IInvoiceService
    {
        void CreateInvoice(int idUser, List<int> idAllocatedTimes);
    }
}
