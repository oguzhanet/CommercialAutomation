using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Business.Concrete;
using CommercialAutomation.DataAccess.Concrete.EntityFramework;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        
        public ActionResult Index()
        {
            var result = adminManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            _adminService.Add(admin);
            return RedirectToAction("Index");
        }

        public PartialViewResult AdminPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var result = _adminService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            var result = _adminService.GetById(admin.AdminId);
            admin.Password = result.Password;
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            var result = _adminService.GetById(id);
            _adminService.Delete(result);
            return RedirectToAction("Index");
        }
    }
}