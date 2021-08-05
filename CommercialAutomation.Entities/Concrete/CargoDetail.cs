using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class CargoDetail : IEntity
    {
        [Key]
        public int CargoDetailId { get; set; }
        [StringLength(300)]
        public string CargoDescription { get; set; }
        [StringLength(10)]
        public string TrackingCode { get; set; }
        public DateTime CargoDate { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
