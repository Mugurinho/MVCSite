using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSite.Models.Repositories;
using MVCSite.ViewModels;
using MVCSite.Models.Data;
using System.Net;

namespace MVCSite.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController(EmployeeRepository er, CompanyRepository cr)
        {
            _er = er;
            _cr = cr;
        }
        protected EmployeeRepository _er;
        protected CompanyRepository _cr;

        public ActionResult Index()
        {
            var vm = new EmployeeViewModel();
            vm.Employees = _er.GetAll().OrderBy(x => x.FirstName);
            if (vm.Employees == null && vm.Employees.Count() < 0) throw new HttpException(404, "The resource you are looking could have been removed, had its name changed, or is temporarily unavailable.");
            return View(vm);
        }

        //Create
        public ActionResult Create()
        {
            var vm = new EmployeeViewModel();
            vm.CompanyList = new List<SelectListItem>();
            vm.Companies = _cr.GetAll();
            if (vm.Companies == null && vm.Companies.Count() < 0)
            {
                throw new HttpException(404, "Companies not found!");
            }
            foreach (var company in vm.Companies)
            {
                vm.CompanyList.Add(new SelectListItem { Text = company.Name, Value = company.CompanyID.ToString() });
            }
            return View(vm);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Employee employee, string companyId)
        {
            var vm = new EmployeeViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    vm.Employee = _er.CreateEmployee(employee, companyId);
                    if (vm.Employee == null)
                    {
                        throw new HttpException(404, "Employee not found!");
                    }
                    _er.SubmitChanges();
                    return RedirectToAction("Index", vm);
                }
                catch (Exception)
                {
                    throw new HttpException(404, "Unexpected error!");
                }
            }
            return View("Create");
        }


        //added for Edit
        public ActionResult Edit(int id)
        {
            var vm = new EmployeeViewModel();
            vm.CompanyList = new List<SelectListItem>();
            vm.Companies = _cr.GetAll();
            vm.Employee = _er.GetByID(id);
            if (vm.Employee == null)
            {
                return HttpNotFound();
            }
            foreach (var company in vm.Companies)
            {
                vm.CompanyList.Add(new SelectListItem { Text = company.Name, Value = company.CompanyID.ToString() });
            }
            return View(vm);
        }

        //Edit post
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, Employee employee)
        {
            var vm = new EmployeeViewModel();
            vm.Employee = _er.GetByID(id);
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Employee == null)
                    {
                        throw new HttpException(404, "Employee not found!");
                    }
                    vm.Employee.FirstName = employee.FirstName;
                    vm.Employee.LastName = employee.LastName;
                    vm.Employee.Email = employee.Email;
                    vm.Employee.Telephone = employee.Telephone;
                    vm.Employee.Company = _cr.GetAll(x => x.CompanyID == employee.CompanyID).FirstOrDefault();
                    _er.SubmitChanges();
                    return RedirectToAction("Index", vm);
                }
                catch (Exception)
                {
                    throw new HttpException(404, "Unexpected error!");
                }
            }
            return RedirectToAction("Edit", new { id = vm.Employee.EmployeeID});
        }

    }
}