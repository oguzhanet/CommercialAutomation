using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.DataAccess.Concrete.EntityFramework;
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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(x => x.CategoryId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
