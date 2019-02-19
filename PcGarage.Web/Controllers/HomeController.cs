using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcGarage.Models;
using PcGarage.Interfaces;
using PcGarage.BusinessLogic;

namespace PcGarage.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductManager manager;

        public HomeController()
        {
            manager = new SqlProductManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}