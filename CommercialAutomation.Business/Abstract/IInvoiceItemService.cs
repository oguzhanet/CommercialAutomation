using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface IInvoiceItemService
    {
        List<InvoiceItem> GetAll();
        InvoiceItem GetById(int id);
        void Add(InvoiceItem ınvoiceItem);
        void Update(InvoiceItem ınvoiceItem);
        void Delete(InvoiceItem ınvoiceItem);
    }
}
