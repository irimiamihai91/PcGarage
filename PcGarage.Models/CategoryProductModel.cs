using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcGarage.Models
{
    public class CategoryProductModel 
    {
        //public int CategoryId { get; set; }

        //public string CategoryName { get; set; }

        //public int ProductId { get; set; }

        //public string ProductName { get; set; }

        //public string Description { get; set; }

        //public string Display { get; set; }

        //public decimal Price { get; set; }

        //public string Photo { get; set; }

        public List<Category> categories { get; set; }

        public List<Product> products { get; set; }
    }
}
