using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Entities.Concrete
{
    public class Invoice : IEntity
    {
        [Key]
        public int InvoiceId { get; set; }
        [StringLength(20)]
        public string InvoiceSerialNumber { get; set; }
        [StringLength(20)]
        public string InvoiceSequenceNumber { get; set; }
        [StringLength(50)]
        public string TaxAdministration { get; set; }
        [StringLength(50)]
        public string DeliveryPerson { get; set; }
        [StringLength(50)]
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
