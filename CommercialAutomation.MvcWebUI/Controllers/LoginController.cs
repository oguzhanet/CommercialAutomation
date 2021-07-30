using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ICustomerService _customerService;

        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
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
                customer.CustomerRole = "C";
                customer.CustomerStatus = true;
                _customerService.Add(customer);           
            }
            return PartialView();
        }
    }
}