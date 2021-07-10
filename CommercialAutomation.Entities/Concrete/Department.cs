using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Department:IEntity
    {
        [Key]
        public int DepartmentId { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public bool DepartmentStatus { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
