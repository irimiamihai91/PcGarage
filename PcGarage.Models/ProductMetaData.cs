using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcGarage.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }

    public class ProductMetaData
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Display { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public string Memory { get; set; }
        [Required]
        public string VideoMemory { get; set; }
        [Required]
        public string HDD { get; set; }
        [Required]
        public string Camera { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}
