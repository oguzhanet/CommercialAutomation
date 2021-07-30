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
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void Add(ToDoList toDoList)
        {
            _toDoListDal.Add(toDoList);
        }

        public void Delete(ToDoList toDoList)
        {
            _toDoListDal.Delete(toDoList);
        }

        public List<ToDoList> GetAll()
        {
            return _toDoListDal.GetAll();
        }

        public ToDoList GetById(int id)
        {
            return _toDoListDal.Get(x => x.ToDoListId == id);
        }

        public void Update(ToDoList toDoList)
        {
            _toDoListDal.Update(toDoList);
        }
    }
}
