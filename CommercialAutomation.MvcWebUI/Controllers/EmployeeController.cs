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
using PagedList;
using PagedList.Mvc;

namespace CommercialAutomation.MvcWebUI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());
        IEmployeeService _employeeService;
        IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public ActionResult Index(int page=1)
        {
            var result = employeeManager.GetAll().ToPagedList(page,6);
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueDepartment = (from department in _departmentService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = department.DepartmentName,
                                                      Value = department.DepartmentId.ToString()
                                                  }).ToList();
            ViewBag.valueDepartment = valueDepartment;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            employee.EmployeeStatus = true;
            _employeeService.Add(employee);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> valueDepartment = (from department in _departmentService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = department.DepartmentName,
                                                        Value = department.DepartmentId.ToString()
                                                    }).ToList();
            ViewBag.valueDepartment = valueDepartment;

            var result = _employeeService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            var result = _employeeService.GetById(employee.EmployeeId);
            employee.EmployeeStatus = result.EmployeeStatus;
            _employeeService.Update(employee);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = employeeManager.GetById(id);

            if (result.EmployeeStatus == true)
            {
                result.EmployeeStatus = false;
            }
            else
            {
                result.EmployeeStatus = true;
            }

            employeeManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}