using CommercialAutomation.Business.Abstract;
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
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
        IDepartmentService _departmentService;
        IEmployeeService _employeeService;
        ISaleMovementService _saleMovementService;
        Context _context;

        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService, ISaleMovementService saleMovementService, Context context)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
            _saleMovementService = saleMovementService;
            _context = context;
        }

        public ActionResult Index()
        {
            var result = departmentManager.GetAll();
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var result = _employeeService.GetAllByDepartmentId(id);

            var departmentName = _context.Departments.Where(x => x.DepartmentId == id).Select(z => z.DepartmentName).FirstOrDefault();
            ViewBag.departmentName = departmentName;
            
            return View(result);
        }

        public ActionResult DepartmentSaleMovement(int id)
        {
            var result = _saleMovementService.GetAllByEmployeeId(id);

            var name = _context.Employees.Where(x => x.EmployeeId == id).Select(z => z.EmployeeName + " " + z.EmployeeLastName).FirstOrDefault();
            ViewBag.name = name;

            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            department.DepartmentStatus = true;
            _departmentService.Add(department);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = _departmentService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Department department)
        {
            var result = _departmentService.GetById(department.DepartmentId);
            department.DepartmentStatus = result.DepartmentStatus;
            _departmentService.Update(department);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = departmentManager.GetById(id);

            if (result.DepartmentStatus==true)
            {
                result.DepartmentStatus = false;
            }
            else
            {
                result.DepartmentStatus = true;
            }

            departmentManager.Update(result);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }
    }
}