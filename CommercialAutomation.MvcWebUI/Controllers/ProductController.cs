﻿using CommercialAutomation.Business.Abstract;
using CommercialAutomation.Business.Concrete;
using CommercialAutomation.DataAccess.Concrete;
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
    public class ProductController : Controller
    {
        // GET: Product

        IProductService _productService;
        ICategoryService _categoryService;
        Context _context;

        public ProductController(IProductService productService, ICategoryService categoryService, Context context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
        }

        ProductManager productManager = new ProductManager(new EfProductDal());

        public ActionResult Index()
        {
            var result = productManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueCategory = (from category in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            product.ProductStatus = true;
            _productService.Add(product);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> valueCategory = (from category in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;

            var result = _productService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            var result = _productService.GetById(product.ProductId);
            product.ProductStatus = result.ProductStatus;
            _productService.Update(product);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = productManager.GetById(id);

            if (result.ProductStatus == true)
            {
                result.ProductStatus = false;
            }
            else
            {
                result.ProductStatus = true;
            }

            productManager.Update(result);
            return RedirectToAction("Index");
        }

        public ActionResult ProductDetail()
        {
            var result = productManager.GetAll().Where(x => x.ProductId == 1).ToList();
            var result1 = _context.Products.Sum(x => x.SalePrice) * 25 / 100;
            ViewBag.result1 = result1;
            return View(result);
        }

        [HttpGet]
        public ActionResult Sale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sale(SaleMovement saleMovement)
        {
            return View();
        }

        public ActionResult ProductList()
        {
            var result = productManager.GetAll();
            return View(result);
        }
    }
}