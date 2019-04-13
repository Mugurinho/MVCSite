using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSite.Models.Repositories;
using MVCSite.ViewModels;

namespace MVCSite.Controllers
{
    public class CompanyController : Controller
    {
        public CompanyController(CompanyRepository cr)
        {
            _cr = cr;
        }
        protected CompanyRepository _cr;

        public ActionResult Index()
        {
            var vm = new CompanyViewModel();
            vm.Companies = _cr.GetAll().OrderBy(x => x.Name);
            if (vm.Companies == null && vm.Companies.Count() < 0) throw new HttpException(404, "The resource you are looking could have been removed, had its name changed, or is temporarily unavailable.");
            return View(vm);
        }
    }
}