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
    public class CategoryController : Controller
    {
        private ICategoryManager categoryManager;

        public CategoryController()
        {
            categoryManager = new SqlCategoryManager();
        }

        public ActionResult Index()
        {
            List<Category> categoryList = categoryManager.GetAllCategoryEntity().ToList();

            //List<Category> categoryList = categoryManager.GetAllCategoryAdo().ToList();

            return View(categoryList);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = categoryManager.GetCategoryAdo(id);

            //Category category = categoryManager.GetCategoryEntity(categoryId);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryManager.EditCategoryEntity(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            categoryManager.AddCategoryEntity(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete( int id)
        {
            Category category = categoryManager.GetCategoryAdo(id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            categoryManager.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Category category = categoryManager.GetCategoryAdo(id);
            return View(category);
        }







    }
}