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
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(ToDoList toDoList)
        {
            _toDoListDal.Add(toDoList);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(ToDoList toDoList)
        {
            _toDoListDal.Delete(toDoList);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<ToDoList> GetAll()
        {
            return _toDoListDal.GetAll();
        }

        public ToDoList GetById(int id)
        {
            return _toDoListDal.Get(x => x.ToDoListId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(ToDoList toDoList)
        {
            _toDoListDal.Update(toDoList);
        }
    }
}
