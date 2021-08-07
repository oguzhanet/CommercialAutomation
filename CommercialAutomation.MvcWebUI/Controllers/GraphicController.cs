using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        IProductService _productService;
        Context _context;
        ArrayList _xvalue;
        ArrayList _yvalue;

        public GraphicController(IProductService productService,Context context, ArrayList xvalue, ArrayList yvalue)
        {
            _productService = productService;
            _context = context;
            _xvalue = xvalue;
            _yvalue = yvalue;
        }

        public ActionResult Index()
        {
            var result = _productService.GetAll();
            result.ToList().ForEach(x => _xvalue.Add(x.ProductName));
            result.ToList().ForEach(y => _yvalue.Add(y.UnitsInStock));
            var graphic = new Chart(width: 600, height: 600)
                .AddTitle("Stocklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: _xvalue, yValues: _yvalue);

            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}