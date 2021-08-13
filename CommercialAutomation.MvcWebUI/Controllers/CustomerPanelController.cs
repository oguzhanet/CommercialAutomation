using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Concrete;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    [Authorize]
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        ICustomerService _customerService;
        IMessageService _messageService;
        ICargoDetailService _cargoDetailService;
        ICargoFollowService _cargoFollowService;
        Context _context;

        public CustomerPanelController(ICustomerService customerService, IMessageService messageService, ICargoDetailService cargoDetailService, ICargoFollowService cargoFollowService, Context context)
        {
            _customerService = customerService;
            _messageService = messageService;
            _cargoDetailService = cargoDetailService;
            _cargoFollowService = cargoFollowService;
            _context = context;
        }

        [HttpGet]
        public ActionResult Index(int id=0)
        {
            var parameter = (string)Session["CustomerMail"];
            //var result = _context.Customers.FirstOrDefault(x => x.CustomerMail == parameter);

            id = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerId).FirstOrDefault();
            var result = _customerService.GetById(id);
            
            var customerImage = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerImage).FirstOrDefault();
            ViewBag.customerImage = customerImage;

            var customerName = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerName + " " + z.CustomerLastName).FirstOrDefault();
            ViewBag.customerName = customerName;

            var customerId = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerId).FirstOrDefault();
            var customerSale = _context.SaleMovements.Where(x => x.CustomerId == customerId).Count();
            ViewBag.customerSale = customerSale;

            var customerMessage = _context.Messages.Where(x => x.ReceiverMail == parameter).Count();
            ViewBag.customerMessage = customerMessage;
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

        public ActionResult InBox()
        {
            var parameter = (string)Session["CustomerMail"];
            var result = _messageService.GetAllInbox(parameter).OrderByDescending(x=>x.MessageId).ToList();
            return View(result);
        }

        public ActionResult SendBox()
        {
            var parameter = (string)Session["CustomerMail"];
            var result = _messageService.GetAllSendbox(parameter).OrderByDescending(x => x.MessageId).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var parameter = (string)Session["CustomerMail"];
            message.SenderMail = parameter;
            message.MessageDate= DateTime.Parse(DateTime.Now.ToShortTimeString());
            _messageService.Add(message);
            Thread.Sleep(1500);
            return RedirectToAction("SendBox");
        }

        public ActionResult CargoFollow(string search, int id=0)
        {
            var parameter = (string)Session["CustomerMail"];
            id = _context.Customers.Where(x => x.CustomerMail == parameter).Select(z => z.CustomerId).FirstOrDefault();
            //var result = _cargoDetailService.GetAllByCustomerId(id);
            var result = from x in _context.CargoDetails where x.CustomerId==id select x;
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(z => z.TrackingCode.Contains(search));
            }
            return View(result.ToList());
        }

        public ActionResult CargoFollowDetail(string id)
        {
            var result = _cargoFollowService.GetAllByFollowCode(id);
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

        public PartialViewResult MessageLayout()
        {
            //var parameter = (string)Session["CustomerMail"];
            //var result = _messageService.GetAllInbox(parameter).OrderByDescending(x => x.MessageId).ToList();
            //ViewBag.result = result.Count();
   
            return PartialView();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}