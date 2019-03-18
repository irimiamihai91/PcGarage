using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcGarage.Models;
using System.Web.Mvc;

namespace PcGarage.Interfaces
{
    public interface ICategoryManager
    {

        IList<Category> GetAllCategoryAdo();

        IList<Category> GetAllCategoryEntity();


        Category GetCategoryEntity(int categoryId);


        Category GetCategoryAdo(int categoryId);


        void AddCategoryAdo(Category category);


        void AddCategoryEntity(Category category);


        void EditCategoryEntity(Category category);


        IEnumerable<SelectListItem> GetCategoriesListForDropdownList();


        void Delete(int id);



    }
}
