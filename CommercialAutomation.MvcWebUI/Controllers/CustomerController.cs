using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Business.Concrete;
using CommercialAutomation.DataAccess.Concrete;
using CommercialAutomation.DataAccess.Concrete.EntityFramework;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        ICustomerService _customerService;
        ISaleMovementService _saleMovementService;
        Context _context;

        public CustomerController(ICustomerService customerService, ISaleMovementService saleMovementService, Context context)
        {
            _customerService = customerService;
            _saleMovementService = saleMovementService;
            _context = context;
        }

        public ActionResult Index()
        {
            var result = customerManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            customer.CustomerStatus = true;
            _customerService.Add(customer);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = _customerService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            var result = _customerService.GetById(customer.CustomerId);
            customer.CustomerStatus = result.CustomerStatus;
            _customerService.Update(customer);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = customerManager.GetById(id);

            if (result.CustomerStatus == true)
            {
                result.CustomerStatus = false;
            }
            else
            {
                result.CustomerStatus = true;
            }

            customerManager.Update(result);
            return RedirectToAction("Index");
        }

        public ActionResult CustomerReceive(int id)
        {
            var result = _saleMovementService.GetAllByCustomerId(id);

            var customerName = _context.Customers.Where(x => x.CustomerId == id).Select(x => x.CustomerName + " " + x.CustomerLastName).FirstOrDefault();
            ViewBag.customerName = customerName;
            return View(result);
        }
    }
}