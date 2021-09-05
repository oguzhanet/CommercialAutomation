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
    public class CargoDetailManager : ICargoDetailService
    {
        private ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Add(cargoDetail);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Delete(cargoDetail);
        }


        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<CargoDetail> GetAll()
        {
            return _cargoDetailDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<CargoDetail> GetAllByCustomerId(int id)
        {
            return _cargoDetailDal.GetAllById(x => x.CustomerId == id);
        }

        public CargoDetail GetById(int id)
        {
            return _cargoDetailDal.Get(x => x.CargoDetailId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Update(cargoDetail);
        }
    }
}
