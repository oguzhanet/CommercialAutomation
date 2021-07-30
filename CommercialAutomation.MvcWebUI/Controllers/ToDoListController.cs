using CommercialAutomation.Business.Concrete;
using CommercialAutomation.DataAccess.Concrete;
using CommercialAutomation.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        ToDoListManager toDoListManager = new ToDoListManager(new EfToDoListDal());
        Context _context;

        public ToDoListController(Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var result = toDoListManager.GetAll().OrderByDescending(x=>x.ToDoListId).ToList();

            var result1 = _context.SaleMovements.Count(x => x.SaleDate == DateTime.Today).ToString();
            if (result1 !=null)
            {
                ViewBag.result1 = result1;
            }
            else
            {
                ViewBag.result1 = 0;
            }
            
            var result2 = _context.Products.Count(x => x.UnitsInStock <= 10).ToString();
            ViewBag.result2 = result2;

            var result3 = _context.Customers.Count().ToString();
            ViewBag.result3 = result3;

            var result4 = (from x in _context.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.result4 = result4;

            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var result = toDoListManager.GetById(id);

            if (result.ToDoListStatus == false)
            {
                result.ToDoListStatus = true;
            }

            toDoListManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}