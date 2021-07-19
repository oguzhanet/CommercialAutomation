using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.Entities.Concrete;
using DevFramework.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfInvoiceItemDal:EfEntityRepositoryBase<InvoiceItem,Context>, IInvoiceItemDal
    {
    }
}
