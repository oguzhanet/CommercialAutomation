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
    public class InvoiceItemController : Controller
    {
        // GET: InvoiceItem
        IInvoiceItemService _ınvoiceItemService;
        IInvoiceService _ınvoiceService;

        public InvoiceItemController(IInvoiceItemService ınvoiceItemService, IInvoiceService ınvoiceService)
        {
            _ınvoiceItemService = ınvoiceItemService;
            _ınvoiceService = ınvoiceService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueInvoice = (from ınvoice in _ınvoiceService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = ınvoice.InvoiceSerialNumber,
                                                      Value = ınvoice.InvoiceId.ToString()
                                                  }).ToList();
            ViewBag.valueInvoice = valueInvoice;
            return View();
        }

        [HttpPost]
        public ActionResult Add(InvoiceItem ınvoiceItem)
        {
            _ınvoiceItemService.Add(ınvoiceItem);
            Thread.Sleep(1500);
            return RedirectToAction("Index", "Invoice");
        }
    }
}