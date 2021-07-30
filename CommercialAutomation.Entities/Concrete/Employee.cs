using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Employee : IEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [StringLength(50)]
        public string EmployeeLastName { get; set; }
        [StringLength(100)]
        public string EmployeeAbout { get; set; }
        [StringLength(50)]
        public string EmployeeAddress { get; set; }
        [StringLength(20)]
        public string EmployeePhone { get; set; }
        [StringLength(500)]
        public string EmployeeImage { get; set; }
        public bool EmployeeStatus { get; set; }

        public ICollection<SaleMovement> SaleMovements { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
