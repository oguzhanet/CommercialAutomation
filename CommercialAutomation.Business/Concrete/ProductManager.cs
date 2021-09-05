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
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
