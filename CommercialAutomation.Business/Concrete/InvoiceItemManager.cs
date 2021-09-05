using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.Entities.Concrete;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
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

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemDal.Add(ınvoiceItem);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemDal.Delete(ınvoiceItem);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<InvoiceItem> GetAll()
        {
            return _ınvoiceItemDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<InvoiceItem> GetAllByInvoiceId(int id)
        {
            return _ınvoiceItemDal.GetAllById(x => x.InvoiceId == id);
        }

        public InvoiceItem GetById(int id)
        {
            return _ınvoiceItemDal.Get(x => x.InvoiceItemId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemDal.Update(ınvoiceItem);
        }
    }
}
