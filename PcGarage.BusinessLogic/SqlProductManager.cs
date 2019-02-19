using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcGarage.Interfaces;
using PcGarage.Models;
using PcGarage.DataAcess;

namespace PcGarage.BusinessLogic
{
    public class SqlProductManager : IProductManager
    {
        private PcGarageEntities pge;

        public SqlProductManager()
        {
            pge = new PcGarageEntities();
        }

        public Product Get(int productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            var list = (from prod in pge.Products
                        select prod).ToList();
            return list;
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
