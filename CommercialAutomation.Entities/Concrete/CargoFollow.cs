using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class CargoFollow : IEntity
    {
        [Key]
        public int CargoFollowId { get; set; }
        [StringLength(100)]
        public string CargoFollowDescription { get; set; }
        [StringLength(10)]
        public string CargoFollowCode { get; set; }
        public DateTime CargoFollowDate { get; set; }
    }
}
