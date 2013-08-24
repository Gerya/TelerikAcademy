using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Reports
{
   internal class ProductForVendorsReport
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public decimal Incomes { get; set; }
        public int TaxPercent { get; set; }

    }
}
