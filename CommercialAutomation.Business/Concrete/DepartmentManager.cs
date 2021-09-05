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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Department department)
        {
            _departmentDal.Delete(department);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

        public Department GetById(int id)
        {
            return _departmentDal.Get(x => x.DepartmentId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
