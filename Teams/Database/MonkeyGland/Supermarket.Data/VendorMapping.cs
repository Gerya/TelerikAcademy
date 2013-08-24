using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data
{
    public class VendorMapping : EntityTypeConfiguration<Vendor>
    {
        public VendorMapping()
        {
            this.HasKey(v => v.ID);
            this.Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(v =>v.Name).IsUnicode(true);
            this.Property(v =>v.Name).HasMaxLength(255);
            this.Property(v =>v.Name).IsRequired();

        }
    }
}