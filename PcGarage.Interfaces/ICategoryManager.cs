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
        IList<Category> GetAllCategoryEntity();

        Category GetCategoryEntity(int categoryId);

        IEnumerable<SelectListItem> GetCategoriesListForDropdownList();

        
    }
}
