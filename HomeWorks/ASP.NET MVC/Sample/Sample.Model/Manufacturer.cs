using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }

        public Manufacturer()
        {
            this.Laptops = new HashSet<Laptop>();
        }
    }
}
