using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Business.Concrete;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IDepartmentService>().To<DepartmentManager>().InSingletonScope();
            Bind<IDepartmentDal>().To<EfDepartmentDal>().InSingletonScope();

            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IEmployeeDal>().To<EfEmployeeDal>().InSingletonScope();

            Bind<ISaleMovementService>().To<SaleMovementManager>().InSingletonScope();
            Bind<ISaleMovementDal>().To<EfSaleMovementDal>().InSingletonScope();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IInvoiceService>().To<InvoiceManager>().InSingletonScope();
            Bind<IInvoiceDal>().To<EfInvoiceDal>().InSingletonScope();

            Bind<IInvoiceItemService>().To<InvoiceItemManager>().InSingletonScope();
            Bind<IInvoiceItemDal>().To<EfInvoiceItemDal>().InSingletonScope();

            Bind<IToDoListService>().To<ToDoListManager>().InSingletonScope();
            Bind<IToDoListDal>().To<EfToDoListDal>().InSingletonScope();
        }
    }
}
