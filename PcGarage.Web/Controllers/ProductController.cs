using PcGarage.BusinessLogic;
using PcGarage.Interfaces;
using PcGarage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PcGarage.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager productManager;

        private ICategoryManager categoryManager;

        private IManufacturerManager manufacturerManager;

        public ProductController()
        {
            productManager = new SqlProductManager();

            categoryManager = new SqlCategoryManager();

            manufacturerManager = new SqlManufacturerManager();
        }

        public ActionResult Index(int categoryId)
        {
            IList<Product> products = productManager.GetAllProductsAdo().Where(cat => cat.CategoryId == categoryId).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            Product product = productManager.GetProductAdo(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.CategoryList = categoryManager.GetCategoriesListForDropdownList();
            ViewBag.CategoryList = categoryManager.GetCategoriesListForDropdownList();
            ViewBag.ManufacturerList = manufacturerManager.GetManufacturerListForDropdownList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.AddProductAdo(product);
            }
            return Redirect("Home/Index");
        }




    }
    
}