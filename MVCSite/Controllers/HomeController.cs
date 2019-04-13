using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSite.Models.Repositories;
using MVCSite.ViewModels;

namespace MVCSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(SubMenuRepository smr)
        {
            _smr = smr;
        }
        protected SubMenuRepository _smr;

        public ActionResult Index()
        {
            var vm = new SubMenuViewModel();
            vm.SubMenues = _smr.GetSubMenues();
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This website registers and displays employees and companies";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact details";
            return View();
        }
    }
}