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
using System.Web.Security;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ICustomerService _customerService;
        Context _context;

        public LoginController(ICustomerService customerService, Context context)
        {
            _customerService = customerService;
            _context = context;
        }

        public ActionResult Index()
        {       
            return View();
        }

        [HttpGet]
        public PartialViewResult CustomerRegisterPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult CustomerRegisterPartial(Customer customer)
        {
            if (_customerService.GetBy(customer.CustomerMail) == null)
            {
                SHA512 sha512 = new SHA512CryptoServiceProvider();
                string password = customer.CustomerPassword;
                string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
                customer.CustomerPassword = result;

                customer.CustomerRole = "C";
                customer.CustomerStatus = true;
                _customerService.Add(customer);           
            }
            return PartialView();
        }

        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {

            SHA512 sha512 = new SHA512CryptoServiceProvider();
            string password = customer.CustomerPassword;
            string result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
            customer.CustomerPassword = result;

            var customerInfo = _context.Customers.FirstOrDefault(x => x.CustomerMail == customer.CustomerMail &&
              x.CustomerPassword == result);

            if (customerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(customerInfo.CustomerMail, false);
                Session["CustomerMail"] = customerInfo.CustomerMail;
                return RedirectToAction("Index", "CustomerPanel");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var adminInfo = _context.Admins.FirstOrDefault(x => x.Mail == admin.Mail && x.Password == admin.Password);

            if (adminInfo !=null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.Mail, false);
                Session["Mail"] = adminInfo.Mail;
                return RedirectToAction("Index", "Category");
            }

            return RedirectToAction("Index");
        }
    }
}