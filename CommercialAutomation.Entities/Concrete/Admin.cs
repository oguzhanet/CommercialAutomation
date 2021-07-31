using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Admin:IEntity
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(1000)]
        public string Password { get; set; }
        [StringLength(1)]
        public string Role { get; set; }
    }
}
