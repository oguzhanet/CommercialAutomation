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
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Add(Employee employee)
        {
            _employeeDal.Add(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public List<Employee> GetAllByDepartmentId(int id)
        {
            return _employeeDal.GetAllById(x => x.DepartmentId == id);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.Get(x => x.EmployeeId == id);
        }

        public void Update(Employee employee)
        {
            _employeeDal.Update(employee);
        }
    }
}
