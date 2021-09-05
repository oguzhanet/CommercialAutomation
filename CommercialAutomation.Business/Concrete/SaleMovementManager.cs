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
    public class SaleMovementManager : ISaleMovementService
    {
        ISaleMovementDal _saleMovementDal;

        public SaleMovementManager(ISaleMovementDal saleMovementDal)
        {
            _saleMovementDal = saleMovementDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(SaleMovement saleMovement)
        {
            _saleMovementDal.Add(saleMovement);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(SaleMovement saleMovement)
        {
            _saleMovementDal.Delete(saleMovement);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<SaleMovement> GetAll()
        {
            return _saleMovementDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<SaleMovement> GetAllByCustomerId(int id)
        {
            return _saleMovementDal.GetAllById(x => x.CustomerId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<SaleMovement> GetAllByEmployeeId(int id)
        {
            return _saleMovementDal.GetAllById(x => x.EmployeeId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<SaleMovement> GetAllBySaleId(int id)
        {
            return _saleMovementDal.GetAllById(x => x.SaleMovementId == id);
        }

        public SaleMovement GetById(int id)
        {
            return _saleMovementDal.Get(x => x.SaleMovementId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(SaleMovement saleMovement)
        {
            _saleMovementDal.Update(saleMovement);
        }
    }
}
