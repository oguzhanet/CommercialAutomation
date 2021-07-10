using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
