using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
