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
            IList<Product> products = productManager.GetAllProductsEntity().Where(cat => cat.CategoryId == categoryId).ToList();
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
                productManager.AddProductEntity(product);
                return Redirect(@"http://localhost:57665/Product?categoryId=1");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = categoryManager.GetCategoriesListForDropdownList();
            ViewBag.ManufacturerList = manufacturerManager.GetManufacturerListForDropdownList();

            Product product = productManager.GetProductEntity(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.UpdateProduct(product);
                return Redirect(@"http://localhost:57665/Product?categoryId=1");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            Product product = productManager.GetProductEntity(id);

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {

            productManager.DeleteProductAdo(id);

            return Redirect(@"http://localhost:57665/Product?categoryId=1");
        }




    }
    
}