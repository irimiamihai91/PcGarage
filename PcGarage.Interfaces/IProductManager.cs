using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcGarage.Models;

namespace PcGarage.Interfaces
{
    public interface IProductManager
    {
        IList<Product> GetAllProductsAdo();

        IList<Product> GetAllProductsEntity();

        Product GetProductAdo(int productId);

        Product GetProductEntity(int productId);

        void AddProductAdo(Product product);

        void AddProductEntity(Product product);

        void DeleteProductAdo(int productId);

        void DeleteProductEntity(int productId);

        void SaveProductAdo(Product product);

    }
}
