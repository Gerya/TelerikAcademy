using Supermarket.Data;
using Supermarket.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Reports
{
   public class ExcelReport
    {
       public SupermarketContext DbContext { get; set; }

        public ExcelReport(SupermarketContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void GenerateVendorTotalReport(string filePath, List<ProductReportJson> listOfProduct)
        {

            SupermarketEntities sqliteCotext = new SupermarketEntities();

            var hashWithProducts = new Dictionary<string , Supermarket.Sqlite.Product>();
            var productsFromSqlite =  sqliteCotext.Products.ToList();

            foreach (var item in productsFromSqlite)
            {
                string itemName = item.ProductName;
                if (!hashWithProducts.ContainsKey(itemName))
                {
                    hashWithProducts.Add(itemName, item);
                }
               
            }

            

            var matching = (from prod in listOfProduct where hashWithProducts.ContainsKey(prod.Name)
                           
                           select
                               new ProductForVendorsReport
            {
                 Id = prod.ProductId,
                 Incomes = prod.Incomes,
                 TaxPercent = hashWithProducts[prod.Name].PercentTax

            }).OrderBy( a=> a.Id).ToList();

            var vendorsFRomSql = (from prod in this.DbContext.Products
                         
                          select new 
                              {
                                  ProductName = prod.Name,
                                  VendorName = prod.Vendor.Name,
                                  Id = prod.ID
                              }).ToList();

            var vendors = (from prod in vendorsFRomSql
                           where hashWithProducts.ContainsKey(prod.ProductName)
                          
                           select new ProductForVendorsReport
                           {
                               VendorName = prod.VendorName,
                               Id = prod.Id
                           }).OrderBy(a => a.Id).ToList();
            List<ProductForVendorsReport> report = new List<ProductForVendorsReport>();
            for (int i = 0; i < matching.Count; i++)
            {
                report.Add(new ProductForVendorsReport
                {
                    Id = matching[i].Id,
                    Incomes = matching[i].Incomes,
                    TaxPercent = matching[i].TaxPercent,
                    VendorName = vendors[i].VendorName,

                });

                Debug.Assert(matching[i].Id == vendors[i].Id);
            }


        
           // var matches =  from prod in listOfProduct where prod.Name
        }
    }
}
