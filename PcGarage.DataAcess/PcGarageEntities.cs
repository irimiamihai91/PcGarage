using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PcGarage.Models;

namespace PcGarage.DataAcess
{
    public partial class PcGarageEntities : DbContext
    {
        public PcGarageEntities()
            : base("name=PcGarageEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

       
    }
}
