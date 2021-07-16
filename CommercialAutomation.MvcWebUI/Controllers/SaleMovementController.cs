using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Business.Concrete;
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
    public class SaleMovementController : Controller
    {
        // GET: SaleMovement
        SaleMovementManager saleMovementManager = new SaleMovementManager(new EfSaleMovementDal());
        ISaleMovementService _saleMovementService;
        IProductService _productService;
        IEmployeeService _employeeService;
        ICustomerService _customerService;

        public SaleMovementController(ISaleMovementService saleMovementService, IProductService productService, IEmployeeService employeeService, ICustomerService customerService)
        {
            _saleMovementService = saleMovementService;
            _productService = productService;
            _employeeService = employeeService;
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var result = saleMovementManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueProduct = (from product in _productService.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = product.ProductName,
                                                     Value = product.ProductId.ToString()
                                                 }).ToList();
            ViewBag.valueProduct = valueProduct;

            List<SelectListItem> valueEmployee = (from employee in _employeeService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = employee.EmployeeName + " " + employee.EmployeeLastName,
                                                      Value = employee.EmployeeId.ToString()
                                                  }).ToList();
            ViewBag.valueEmployee = valueEmployee;

            List<SelectListItem> valueCustomer = (from customer in _customerService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = customer.CustomerName + " " + customer.CustomerLastName,
                                                      Value = customer.CustomerId.ToString()
                                                  }).ToList();
            ViewBag.valueCustomer = valueCustomer;
            return View();
        }

        [HttpPost]
        public ActionResult Add(SaleMovement saleMovement)
        {
            saleMovement.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _saleMovementService.Add(saleMovement);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> valueProduct = (from product in _productService.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = product.ProductName,
                                                     Value = product.ProductId.ToString()
                                                 }).ToList();
            ViewBag.valueProduct = valueProduct;

            List<SelectListItem> valueEmployee = (from employee in _employeeService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = employee.EmployeeName + " " + employee.EmployeeLastName,
                                                      Value = employee.EmployeeId.ToString()
                                                  }).ToList();
            ViewBag.valueEmployee = valueEmployee;

            List<SelectListItem> valueCustomer = (from customer in _customerService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = customer.CustomerName + " " + customer.CustomerLastName,
                                                      Value = customer.CustomerId.ToString()
                                                  }).ToList();
            ViewBag.valueCustomer = valueCustomer;

            var result = _saleMovementService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(SaleMovement saleMovement)
        {
            var result = _saleMovementService.GetById(saleMovement.SaleMovementId);
            saleMovement.SaleDate = result.SaleDate;
            _saleMovementService.Update(saleMovement);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }
    }
}