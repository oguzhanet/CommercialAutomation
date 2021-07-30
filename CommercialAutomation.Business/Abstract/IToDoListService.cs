using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface IToDoListService
    {
        List<ToDoList> GetAll();
        ToDoList GetById(int id);
        void Add(ToDoList toDoList);
        void Update(ToDoList toDoList);
        void Delete(ToDoList toDoList);
    }
}
