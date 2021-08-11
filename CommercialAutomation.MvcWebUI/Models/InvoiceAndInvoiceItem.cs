using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommercialAutomation.MvcWebUI.Models
{
    public class InvoiceAndInvoiceItem
    {
        public IEnumerable<Invoice> InvoiceValue { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItemValue { get; set; }
    }
}