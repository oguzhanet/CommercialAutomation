using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        IInvoiceService _ınvoiceService;

        public InvoiceController(IInvoiceService ınvoiceService)
        {
            _ınvoiceService = ınvoiceService;
        }

        public ActionResult Index()
        {
            var result = _ınvoiceService.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Invoice ınvoice)
        {
            ınvoice.Date = DateTime.Parse(DateTime.Now.ToShortTimeString());
            _ınvoiceService.Add(ınvoice);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }
    }
}