using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        List<Employee> GetAllByDepartmentId(int id);
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
