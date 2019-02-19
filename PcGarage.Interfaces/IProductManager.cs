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
        void Save(Product product);

        Product Get(int productId);

        IList<Product> GetAll();
    }
}
