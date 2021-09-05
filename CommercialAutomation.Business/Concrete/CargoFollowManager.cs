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
    public class CargoFollowManager : ICargoFollowService
    {
        private ICargoFollowDal _cargoFollowDal;

        public CargoFollowManager(ICargoFollowDal cargoFollowDal)
        {
            _cargoFollowDal = cargoFollowDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(CargoFollow cargoFollow)
        {
            _cargoFollowDal.Add(cargoFollow);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(CargoFollow cargoFollow)
        {
            _cargoFollowDal.Delete(cargoFollow);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<CargoFollow> GetAll()
        {
            return _cargoFollowDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<CargoFollow> GetAllByFollowCode(string followCode)
        {
            return _cargoFollowDal.GetAll(x => x.CargoFollowCode == followCode);
        }

        public CargoFollow GetById(int id)
        {
            return _cargoFollowDal.Get(x => x.CargoFollowId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(CargoFollow cargoFollow)
        {
            _cargoFollowDal.Update(cargoFollow);
        }
    }
}
