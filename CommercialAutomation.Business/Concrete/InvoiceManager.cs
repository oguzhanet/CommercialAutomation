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
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceDal _ınvoiceDal;

        public InvoiceManager(IInvoiceDal ınvoiceDal)
        {
            _ınvoiceDal = ınvoiceDal;
        }

        public void Add(Invoice ınvoice)
        {
            _ınvoiceDal.Add(ınvoice);
        }

        public void Delete(Invoice ınvoice)
        {
            _ınvoiceDal.Delete(ınvoice);
        }

        public List<Invoice> GetAll()
        {
            return _ınvoiceDal.GetAll();
        }

        public Invoice GetById(int id)
        {
            return _ınvoiceDal.Get(x => x.InvoiceId == id);
        }

        public void Update(Invoice ınvoice)
        {
            _ınvoiceDal.Update(ınvoice);
        }
    }
}
