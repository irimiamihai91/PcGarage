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

        private ICategoryManager manager;

        public HomeController()
        {
            manager = new SqlCategoryManager();
        }
        public ActionResult Index()
        {
            List<Category> categories = manager.GetAllCategoryEntity().ToList();
            return View(categories);
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