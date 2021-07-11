using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Business.Concrete;
using CommercialAutomation.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public ActionResult Index()
        {
            var result = departmentManager.GetAll();
            return View(result);
        }
    }
}