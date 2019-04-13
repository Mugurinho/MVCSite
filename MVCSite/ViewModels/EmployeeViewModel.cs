using MVCSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCSite.ViewModels
{
    public class EmployeeViewModel
    {
        public IQueryable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public IQueryable<Company> Companies { get; set; }
    }
}