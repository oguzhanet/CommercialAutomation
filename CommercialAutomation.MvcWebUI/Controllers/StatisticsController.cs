using CommercialAutomation.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context _context;

        public StatisticsController(Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var result1 = _context.Customers.Count().ToString();
            ViewBag.result1 = result1;

            var result2 = _context.Employees.Count().ToString();
            ViewBag.result2 = result2;

            var result3 = _context.Categories.Count().ToString();
            ViewBag.result3 = result3;

            var result4 = _context.Products.Count().ToString();
            ViewBag.result4 = result4;

            return View();
        }
    }
}