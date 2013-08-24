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
   public class MeasureMapping : EntityTypeConfiguration<Measure>
    {
        public MeasureMapping()
        {
            this.HasKey(m => m.ID);
            this.Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(m => m.Name).IsUnicode(true);
            this.Property(m => m.Name).HasMaxLength(255);
            this.Property(m => m.Name).IsRequired();
           
        }
    }
}