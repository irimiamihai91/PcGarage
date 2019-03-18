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
    public class SqlCategoryProductManager
    {
        private DataAcess.PcGarageEntities pge;
        private PcGarageAdoNet pga;

        public SqlCategoryProductManager()
        {
            pge = new DataAcess.PcGarageEntities();

            pga = new PcGarageAdoNet();
        }

        //public IList<CategoryProductModel> GetCategory()
        //{
        //    //IList<Category> categoryList = pge.Categories.ToList();

        //    //CategoryProductModel category = new CategoryProductModel();

        //    List<CategoryProductModel> categoryVM = new List<CategoryProductModel>();
           
        //    return categoryVM;
        //}

        //public IList<CategoryProductModel> GetProducts()
        //{
        //    IList<Product> productList = pge.Products.ToList();

        //    CategoryProductModel product = new CategoryProductModel();

        //    IList<CategoryProductModel> productVM = productList.Select(x => new CategoryProductModel;
        
        //    return productVM;
        //}
    }
}
