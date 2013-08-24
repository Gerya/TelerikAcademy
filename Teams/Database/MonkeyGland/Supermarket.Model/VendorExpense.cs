using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    public class VendorExpense
    {
        public int Id { get; set; }
        public decimal MonthExpense { get; set; }
        public DateTime Date { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
