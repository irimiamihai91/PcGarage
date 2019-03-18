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
       
        private ICategoryManager categoryManager;
        private IProductManager productManager;


        public HomeController()
        {
            categoryManager = new SqlCategoryManager();
            productManager = new SqlProductManager();

        }
        public ActionResult Index()
        {

            //List<Category> categories = categoryManager.GetAllCategoryEntity().ToList();
            //return View(categories);

            //IList<CategoryProductModel> categoryVM = categoryproductManager.GetCategory().ToList();
            //IList<CategoryProductModel> productVM = categoryproductManager.GetProducts().ToList();

            //List<Category> categoryVM = CategoryProductModel.
            //List<CategoryProductModel> productVm = new List<CategoryProductModel>();

            var viewModel = new CategoryProductModel
            {
                categories = categoryManager.GetAllCategoryEntity().ToList(),
                products = productManager.GetAllProductsEntity().ToList()

            };
            return View(viewModel);

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