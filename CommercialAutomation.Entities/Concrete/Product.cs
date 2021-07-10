using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [StringLength(500)]
        public string ProductImage { get; set; }
        public short UnitsInStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool ProductStatus { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<SaleMovement> SaleMovements { get; set; }
    }
}
