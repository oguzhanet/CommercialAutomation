using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface IInvoiceService
    {
        List<Invoice> GetAll();
        Invoice GetById(int id);
        void Add(Invoice ınvoice);
        void Update(Invoice ınvoice);
        void Delete(Invoice ınvoice);
    }
}
