using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class InvoiceItem : IEntity
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SumPrice { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
