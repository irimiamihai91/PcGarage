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
    public class SqlProductManager : IProductManager
    {
        private DataAcess.PcGarageEntities pge;
        private PcGarageAdoNet pga;

        public SqlProductManager()
        {
            pge = new DataAcess.PcGarageEntities();
            pga = new PcGarageAdoNet();
        }

        public IList<Product> GetAllProductsAdo()
        {
            SqlConnection conn = pga.OpenConnection();

            IList<Product> productList = new List<Product>();

            SqlCommand command = new SqlCommand("spGetAllProducts", conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = command.ExecuteReader()) {

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(reader["ProductId"]);
                    product.ProductName = (reader["ProductName"]).ToString();
                    product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    product.ManufacturerId = Convert.ToInt32(reader["ManufacturerId"]);
                    product.Description = (reader["Description"].ToString());
                    product.Stock = Convert.ToInt32(reader["Stock"]);
                    product.Price = Convert.ToInt32(reader["Price"]);
                    product.Display = (reader["Display"].ToString());
                    product.Processor = (reader["Processor"].ToString());
                    product.Memory = (reader["Memory"].ToString());
                    product.VideoMemory = (reader["VideoMemory"].ToString());
                    product.HDD = (reader["HDD"].ToString());
                    product.Camera = (reader["Camera"].ToString());

                    productList.Add(product);

                }
                }

            pga.CloseConnection(conn);

            return productList;

            //Create Procedure spGetAllProducts
            //As
            //Begin
            //Select* from Product
            //End

            
        }

        public IList<Product> GetAllProductsEntity()
        {
            List<Product> productList = pge.Products.ToList();
            pge.SaveChanges();

            return productList;
        }

        public Product GetProductAdo(int productId)
        {


           
           
                SqlConnection conn = pga.OpenConnection();
                SqlCommand command = new SqlCommand("spGetProduct", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter productIdParam = pga.CreateParameterByValueAndName(productId, "@productId");
                command.Parameters.Add(productIdParam);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductId = Convert.ToInt32(reader["ProductId"]);
                        product.ProductName = (reader["ProductName"]).ToString();
                        product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        product.ManufacturerId = Convert.ToInt32(reader["ManufacturerId"]);
                        product.Description = (reader["Description"].ToString());
                        product.Stock = Convert.ToInt32(reader["Stock"]);
                        product.Price = Convert.ToInt32(reader["Price"]);
                        product.Display = (reader["Display"].ToString());
                        product.Processor = (reader["Processor"].ToString());
                        product.Memory = (reader["Memory"].ToString());
                        product.VideoMemory = (reader["VideoMemory"].ToString());
                        product.HDD = (reader["HDD"].ToString());
                        product.Camera = (reader["Camera"].ToString());

                        

                         return product;

                        
                    }
                }
            pga.CloseConnection(conn);


            return null;

            //Create Procedure spGetProduct @productId int
            //as
            //Begin
            //Select* from Product
            //where ProductId = @productId
            //end

        }

        public Product GetProductEntity(int productId)
        {
            Product product = pge.Products.Single(p =>p.ProductId == productId);
            return product;
        }

        public void AddProductAdo(Product product)
        {
            SqlConnection conn = pga.OpenConnection();
            SqlCommand command = new SqlCommand("spAddProduct1", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter nameParam = pga.CreateParameterByValueAndName(product.ProductName, "@ProductName");
            SqlParameter categoryIdParam = pga.CreateParameterByValueAndName(product.CategoryId, "@CategoryId");
            SqlParameter maufacturerIdParam = pga.CreateParameterByValueAndName(product.ManufacturerId, "@ManufacturerId");
            SqlParameter descriptionParam = pga.CreateParameterByValueAndName(product.Description, "@Description");
            SqlParameter stockParam = pga.CreateParameterByValueAndName(product.Stock, "@Stock");
            SqlParameter priceParam = pga.CreateParameterByValueAndName(product.Price, "@Price");
            SqlParameter displayParam = pga.CreateParameterByValueAndName(product.Display, "@Display");
            SqlParameter processorParam = pga.CreateParameterByValueAndName(product.Processor, "@Processor");
            SqlParameter memoryParam = pga.CreateParameterByValueAndName(product.Memory, "@Memory");
            SqlParameter videoMemoryParam = pga.CreateParameterByValueAndName(product.VideoMemory, "@VideoMemory");
            SqlParameter HDDParam = pga.CreateParameterByValueAndName(product.HDD, "@HDD");
            SqlParameter CameraParam = pga.CreateParameterByValueAndName(product.Camera, "@Camera");
            SqlParameter photoParam = pga.CreateParameterByValueAndName(product.Photo, "@Photo");
            command.Parameters.Add(nameParam);
            command.Parameters.Add(categoryIdParam);
            command.Parameters.Add(maufacturerIdParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(stockParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(displayParam);
            command.Parameters.Add(processorParam);
            command.Parameters.Add(memoryParam);
            command.Parameters.Add(videoMemoryParam);
            command.Parameters.Add(HDDParam);
            command.Parameters.Add(CameraParam);
            command.Parameters.Add(photoParam);
            command.ExecuteNonQuery();
            pga.CloseConnection(conn);

            //            Create Procedure spAddProduct
            //@ProductName varchar(100),
            //@CategoryId int,
            //@ManufacturerId int,
            //@Description varchar(max),
            //@Stock int, --trigger--
            //@Price decimal,
            //@Display varchar(max),
            //@Processor varchar(max),
            //@Memory varchar(max),
            //@VideoMemory varchar(max),
            //@HDD varchar(max),
            //@Camera varchar(200)
            //As
            //begin
            //Insert into Product(ProductName, CategoryId, ManufacturerId, Description, Stock, Price, Display, Processor, Memory, VideoMemory, HDD, Camera)

            //Values(@ProductName, @CategoryId, @ManufacturerId, @Description, @Stock, @Price, @Display, @Processor, @Memory, @VideoMemory, @HDD, @Camera)
            //End

//            Create Procedure spAddProduct1
//@ProductName varchar(100),
//            @CategoryId int,
//            @ManufacturerId int,
//            @Description varchar(max),
//            @Stock int, --trigger--
//            @Price decimal,
//            @Display varchar(max),
//            @Processor varchar(max),
//            @Memory varchar(max),
//            @VideoMemory varchar(max),
//            @HDD varchar(max),
//            @Camera varchar(200),
//			@Photo varchar(200)
//            As
//            Begin
//            Insert into Product(ProductName, CategoryId, ManufacturerId, Description, Stock, Price, Display, Processor, Memory, VideoMemory, HDD, Camera, Photo)

//            Values(@ProductName, @CategoryId, @ManufacturerId, @Description, @Stock, @Price, @Display, @Processor, @Memory, @VideoMemory, @HDD, @Camera, @Photo)
//            End


        }

        public void AddProductEntity(Product product)
        {
            pge.Products.Add(product);
            pge.SaveChanges();
        }

        public void DeleteProductAdo(int productId)
        {
            SqlConnection conn = pga.OpenConnection();

            SqlCommand command = new SqlCommand("spDeleteProduct", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter productIdParam = pga.CreateParameterByValueAndName(productId, "@ProductId");
            command.Parameters.Add(productIdParam);
            command.ExecuteNonQuery();
            pga.CloseConnection(conn);

            //Create Procedure spDeleteProduct @ProductId int
            //    as
            //    begin
            //Delete from Product
            //where ProductId = @ProductId
            //    End
        }

        public void DeleteProductEntity(int productId)
        {
            Product product = pge.Products.Single(p => p.ProductId == productId);
            pge.Products.Remove(product);
            pge.SaveChanges();
        }

        public void SaveProductAdo(Product product)
        {
//            Create Procedure spSaveProduct
//@ProductId int,
//@ProductName varchar(100),
//@CategoryId int,
//@ManufacturerId int,
//@Description varchar(max),
//@Stock int, --trigger--
//@Price decimal,
//@Display varchar(max),
//@Processor varchar(max),
//@Memory varchar(max),
//@VideoMemory varchar(max),
//@HDD varchar(max),
//@Camera varchar(200)
//as
//begin
//Update Product set
//ProductName = @ProductName,
//CategoryId = @CategoryId,
//ManufacturerId = @ManufacturerId,
//Description = @Description,
//Stock = @Stock, --trigger--
//Price = @Price,
//Display = @Display,
//Processor = @Processor,
//Memory = @Memory,
//VideoMemory = @VideoMemory,
//HDD = @HDD,
//Camera = @Camera
//where
//ProductId = @ProductId
//end
            SqlConnection conn = pga.OpenConnection();
            SqlCommand command = new SqlCommand("spSaveProduct",conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter nameParam = pga.CreateParameterByValueAndName(product.ProductName, "@ProductName");
            SqlParameter categoryIdParam = pga.CreateParameterByValueAndName(product.CategoryId, "@CategoryId");
            SqlParameter maufacturerIdParam = pga.CreateParameterByValueAndName(product.ManufacturerId, "@ManufacturerId");
            SqlParameter descriptionParam = pga.CreateParameterByValueAndName(product.Description, "@Description");
            SqlParameter stockParam = pga.CreateParameterByValueAndName(product.Stock, "@Stock");
            SqlParameter priceParam = pga.CreateParameterByValueAndName(product.Price, "@Price");
            SqlParameter displayParam = pga.CreateParameterByValueAndName(product.Display, "@Display");
            SqlParameter processorParam = pga.CreateParameterByValueAndName(product.Processor, "@Processor");
            SqlParameter memoryParam = pga.CreateParameterByValueAndName(product.Memory, "@Memory");
            SqlParameter videoMemoryParam = pga.CreateParameterByValueAndName(product.VideoMemory, "@VideoMemory");
            SqlParameter HDDParam = pga.CreateParameterByValueAndName(product.HDD, "@HDD");
            SqlParameter CameraParam = pga.CreateParameterByValueAndName(product.Camera, "@Camera");
            command.Parameters.Add(nameParam);
            command.Parameters.Add(categoryIdParam);
            command.Parameters.Add(maufacturerIdParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(stockParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(displayParam);
            command.Parameters.Add(processorParam);
            command.Parameters.Add(memoryParam);
            command.Parameters.Add(videoMemoryParam);
            command.Parameters.Add(HDDParam);
            command.Parameters.Add(CameraParam);
            command.ExecuteNonQuery();
            pga.CloseConnection(conn);

        }

       
    }
}
