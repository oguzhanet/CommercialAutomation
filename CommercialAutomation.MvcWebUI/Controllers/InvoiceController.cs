using CommercialAutomation.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}