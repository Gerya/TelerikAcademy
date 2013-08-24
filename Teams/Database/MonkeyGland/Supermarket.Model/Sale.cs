using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
   public class Sale
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Sum { get; set; }
        public DateTime? Date { get; set; }


        public virtual Location Location { get; set; }
        public virtual Product  Product{ get; set; }
    }
}
