using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Supermarket.Model;


namespace Supermarket.Data
{
   
    public class SupermarketContext:DbContext
    {
         public SupermarketContext()
        : base("Supermarket") 
        { 
        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<VendorExpense> VendorsExpences { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tag>().HasKey(x => x.TagId);
            //modelBuilder.Entity<Tag>().Property(x => x.Text).IsUnicode(true);
            //modelBuilder.Entity<Tag>().Property(x => x.Text).HasMaxLength(255);

            //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

            //// modelBuilder.Configurations.Add(new TagMappings());

            //modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new VendorMapping());
            modelBuilder.Configurations.Add(new MeasureMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
