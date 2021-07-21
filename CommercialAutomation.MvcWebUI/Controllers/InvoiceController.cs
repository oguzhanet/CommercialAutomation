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
    public class InvoiceController : Controller
    {
        // GET: Invoice
        InvoiceManager ınvoiceManager = new InvoiceManager(new EfInvoiceDal());
        IInvoiceService _ınvoiceService;
        IInvoiceItemService _ınvoiceItemService;

        public InvoiceController(IInvoiceService ınvoiceService, IInvoiceItemService ınvoiceItemService)
        {
            _ınvoiceService = ınvoiceService;
            _ınvoiceItemService = ınvoiceItemService;
        }

        public ActionResult Index()
        {
            var result = ınvoiceManager.GetAll();
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

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = _ınvoiceService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Invoice ınvoice)
        {
            var result = _ınvoiceService.GetById(ınvoice.InvoiceId);
            ınvoice.Date = result.Date;
            _ınvoiceService.Update(ınvoice);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            var result = _ınvoiceItemService.GetAllByInvoiceId(id);
            return View(result);
        }
    }
}