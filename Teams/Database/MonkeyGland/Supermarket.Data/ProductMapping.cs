using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            this.HasKey(p => p.ID);
            this.Property(p => p.Name).IsUnicode(true);
            this.Property(p => p.Name).HasMaxLength(255);
            this.Property(p => p.Name).IsRequired();
            
        }
    }
}
