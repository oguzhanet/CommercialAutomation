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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        public void Delete(Department department)
        {
            _departmentDal.Delete(department);
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

        public Department GetById(int id)
        {
            return _departmentDal.Get(x => x.DepartmentId == id);
        }

        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
