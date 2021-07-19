using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Concrete
{
    public class InvoiceItemManager : IInvoiceItemService
    {
        IInvoiceItemDal _ınvoiceItemDal;

        public InvoiceItemManager(IInvoiceItemDal ınvoiceItemDal)
        {
            _ınvoiceItemDal = ınvoiceItemDal;
        }

        public void Add(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemDal.Add(ınvoiceItem);
        }

        public void Delete(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemDal.Delete(ınvoiceItem);
        }

        public List<InvoiceItem> GetAll()
        {
            return _ınvoiceItemDal.GetAll();
        }

        public InvoiceItem GetById(int id)
        {
            return _ınvoiceItemDal.Get(x => x.InvoiceItemId == id);
        }

        public void Update(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemDal.Update(ınvoiceItem);
        }
    }
}
