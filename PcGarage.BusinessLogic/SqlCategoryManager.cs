using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcGarage.Interfaces;
using PcGarage.Models;
using PcGarage.DataAcess;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PcGarage.BusinessLogic
{
    public class SqlCategoryManager :ICategoryManager
    {
        private DataAcess.PcGarageEntities pge;
        private PcGarageAdoNet pga;

        public SqlCategoryManager()
        {
            pge = new DataAcess.PcGarageEntities();
            pga = new PcGarageAdoNet();
        }

        public IList<Category> GetAllCategoryEntity()
        {
            List<Category> categoryList = pge.Categories.ToList();
            pge.SaveChanges();

            return categoryList;
        }

        public Category GetCategoryEntity(int categoryId)
        {
            Category category = pge.Categories.Single(c => c.CategoryId == categoryId);
            return category;
        }

        public IEnumerable<SelectListItem> GetCategoriesListForDropdownList()
        {
            
            var categories = pge.Categories.Select(g => g);

            var list = new List<SelectListItem>();

            foreach (var cat in categories)
            {
                list.Add(new SelectListItem
                {
                    Value = cat.CategoryId.ToString(),
                    Text = cat.CategoryName
                });
            }

            return list;
        }
    }
}
