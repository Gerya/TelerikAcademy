using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Model { get; set; }

        [Required]
        public double MonitorSize { get; set; }

        [Required]
        public int HardDiskSize { get; set; }

        [Required]
        public int RamMemorySize { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts  { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Laptop()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

    }
}
