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
    public class SqlCategoryManager : ICategoryManager
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

        public IList<Category> GetAllCategoryAdo()
        {
            //Create Procedure GetAllCategories
            //As
            //Begin

            //Select* from Category
            //end
            

            SqlConnection conn = pga.OpenConnection();

            IList<Category> categoryList = new List<Category>();

            SqlCommand command = new SqlCommand("GetAllCategories", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    category.CategoryName = (reader["CategoryName"]).ToString();
                    

                    categoryList.Add(category);

                }
            }
            

            pga.CloseConnection(conn);

            return categoryList;
        }

        public Category GetCategoryEntity(int categoryId)
        {
            Category category = pge.Categories.SingleOrDefault(c => c.CategoryId == categoryId);
            return category;
        }

        public Category GetCategoryAdo(int categoryId)
        {
            SqlConnection conn = pga.OpenConnection();
            SqlCommand command = new SqlCommand("spGetCatgory", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter categoryIdParam = pga.CreateParameterByValueAndName(categoryId, "@categoryId");
            command.Parameters.Add(categoryIdParam);
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    category.CategoryName = (reader["CategoryName"]).ToString();


                    return category;


                }
            }
            pga.CloseConnection(conn);


            return null;

            //Create Procedure spGetCategory @categoryId int
            //as
            //Begin
            //Select* from Category
            //where CategoryId  = @categoryId
            //end
        }

        public void AddCategoryAdo(Category category)
        {
            SqlConnection conn = pga.OpenConnection();
            SqlCommand command = new SqlCommand("spAddCategory", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter nameParam = pga.CreateParameterByValueAndName(category.CategoryName, "@CategoryName");
            
            command.Parameters.Add(nameParam);
            
            command.ExecuteNonQuery();
            pga.CloseConnection(conn);

         //   Create Procedure spAddCategory
         //@CategoryName varchar(100)
         //   As
         //   begin
         //   Insert into Category(CategoryName)

         //   Values(@CategoryName)
         //   End

        }

        public void AddCategoryEntity(Category category)
        {
            pge.Categories.Add(category);
            pge.SaveChanges();
        }

        public void EditCategoryEntity(Category category)
        {
            Category category_to_be_updated = pge.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            category_to_be_updated.CategoryName = category.CategoryName;
            pge.SaveChanges();
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

        public void Delete(int id)
        {
            pge.Categories.RemoveRange(from c in pge.Categories
                                       where c.CategoryId == id
                                       select c);
            pge.SaveChanges();
        }
    }
}
