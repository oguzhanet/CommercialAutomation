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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var result = categoryManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.CategoryStatus = true;
            categoryManager.Add(category);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = categoryManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var result = categoryManager.GetById(category.CategoryId);
            category.CategoryStatus = result.CategoryStatus;
            categoryManager.Update(category);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var result = categoryManager.GetById(id);

            if (result.CategoryStatus==true)
            {
                result.CategoryStatus = false;
            }
            else
            {
                result.CategoryStatus = true;
            }

            categoryManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}