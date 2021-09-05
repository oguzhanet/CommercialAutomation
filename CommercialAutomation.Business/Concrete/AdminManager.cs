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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
