using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class SaleMovement:IEntity
    {
        [Key]
        public int SaleMovementId { get; set; }
        public int Piece { get; set; }
        public decimal UnitPirce { get; set; }
        public decimal SumPrice { get; set; }
        public DateTime SaleDate { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
