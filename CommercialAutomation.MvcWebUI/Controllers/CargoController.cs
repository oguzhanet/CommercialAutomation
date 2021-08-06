using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Entities.Concrete;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo

        private ICargoDetailService _cargoDetailService;
        private IEmployeeService _employeeService;
        private ICustomerService _customerService;
        private ICargoFollowService _cargoFollowService;
        private Random _random;

        public CargoController(ICargoDetailService cargoDetailService, IEmployeeService employeeService, ICustomerService customerService, ICargoFollowService cargoFollowService, Random random)
        {
            _cargoDetailService = cargoDetailService;
            _employeeService = employeeService;
            _customerService = customerService;
            _cargoFollowService = cargoFollowService;
            _random = random;
        }

        public ActionResult Index()
        {
            var result = _cargoDetailService.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddCargoDetail()
        {
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

            string[] character = { "A", "S", "K", "L", "M", "O", "T" };
            int c1, c2, c3;
            c1 = _random.Next(0, character.Length);
            c2 = _random.Next(0, character.Length);
            c3 = _random.Next(0, character.Length);
            int n1, n2, n3;
            n1 = _random.Next(100, 1000);
            n2 = _random.Next(10, 99);
            n3 = _random.Next(10, 88);
            string code = n1.ToString() + character[c1] + n2 + character[c2] + n3 + character[c3];
            ViewBag.code = code;

            return View();
        }

        [HttpPost]
        public ActionResult AddCargoDetail(CargoDetail cargoDetail)
        {
            //cargoDetail.CargoDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            _cargoDetailService.Add(cargoDetail);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult FollowCargo(string id) //id değeri routeconfigden kaynaklı o şekilde verilmesi gerekiyor
        {
            var result = _cargoFollowService.GetAllByFollowCode(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult QRCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QRCode(string code)
        {
            using (MemoryStream memoryStream=new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qRCode = qRCodeGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitmapImage=qRCode.GetGraphic(10))
                {
                    bitmapImage.Save(memoryStream, ImageFormat.Png);
                    ViewBag.qRCodeImage = "data:images/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}