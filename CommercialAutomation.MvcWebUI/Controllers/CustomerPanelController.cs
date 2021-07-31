using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    [Authorize]
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}