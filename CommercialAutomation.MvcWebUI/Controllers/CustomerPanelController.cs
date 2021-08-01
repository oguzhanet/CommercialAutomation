using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Concrete;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    [Authorize]
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        ICustomerService _customerService;
        Context _context;

        public CustomerPanelController(ICustomerService customerService, Context context)
        {
            _customerService = customerService;
            _context = context;
        }

        [HttpGet]
        public ActionResult Index(int id=0)
        {
            var parameter = (string)Session["CustomerMail"];
            //var result = _context.Customers.FirstOrDefault(x => x.CustomerMail == parameter);

            id = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerId).FirstOrDefault();
            var result = _customerService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            string password = customer.CustomerPassword;
            string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
            if (customer.CustomerPassword == null)
            {
                customer.CustomerPassword = result;
            }
         
            customer.CustomerRole = "C";
            customer.CustomerStatus = true;
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult CustomerOrder()
        {
            var parameter = (string)Session["CustomerMail"];
            var id = _context.Customers.Where(x => x.CustomerMail == parameter.ToString()).Select(z => z.CustomerId).FirstOrDefault();
            var result = _context.SaleMovements.Where(x => x.CustomerId == id).ToList();
            return View(result);
        }

        public PartialViewResult NameLayout()
        {
            var parameter = (string)Session["CustomerMail"];

            var name = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerName + " " + z.CustomerLastName).FirstOrDefault();
            ViewBag.name = name;

            var image = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerImage).FirstOrDefault();
            ViewBag.image = image;

            return PartialView();
        }
    }
}