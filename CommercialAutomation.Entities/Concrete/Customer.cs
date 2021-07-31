using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string CustomerLastName { get; set; }
        [StringLength(50)]
        public string CustomerCity { get; set; }
        [StringLength(50)]
        public string CustomerMail { get; set; }
        [StringLength(15)]
        public string CustomerPhone { get; set; }
        [StringLength(1000)]
        public string CustomerPassword{ get; set; }
        [StringLength(1)]
        public string CustomerRole { get; set; }
        public bool CustomerStatus { get; set; }

        public ICollection<SaleMovement> SaleMovements { get; set; }
    }
}
