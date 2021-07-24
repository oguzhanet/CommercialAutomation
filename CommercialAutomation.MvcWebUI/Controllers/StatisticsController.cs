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

            var result5 = _context.Products.Sum(x => x.UnitsInStock).ToString();
            ViewBag.result5 = result5;

            var result6 = (from x in _context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.result6 = result6;

            var result7 = _context.Products.Count(x => x.UnitsInStock <= 10).ToString();
            ViewBag.result7 = result7;

            var result8 = (from x in _context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.result8 = result8;

            var result9 = (from x in _context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.result9 = result9;

            var result10 = _context.Products.GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.result10 = result10;

            var result11 = _context.Products.Where(x => x.ProductId == (_context.SaleMovements.GroupBy(y => y.ProductId).OrderByDescending(z => z.Count()).Select(a => a.Key).FirstOrDefault())).Select(s=>s.ProductName).FirstOrDefault();
            ViewBag.result11 = result11;

            var result12 = _context.SaleMovements.Sum(x => x.SumPrice).ToString();
            ViewBag.result12 = result12;

            //var result13 = _context.SaleMovements.Count(x => x.SaleDate == DateTime.Today).ToString();
            //ViewBag.result13 = result13;

            //var result14 = _context.SaleMovements.Where(x => x.SaleDate == DateTime.Today).Sum(z => z.SumPrice).ToString();
            //ViewBag.result14 = result14;

            return View();
        }

        public ActionResult EasyTable()
        {
            return View();
        }
    }
}