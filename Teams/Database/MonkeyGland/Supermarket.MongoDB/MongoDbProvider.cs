using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Supermarket.Reports;
using System;
using System.Collections.Generic;
using Supermarket.Model;

namespace Supermarket.MongoDB
{
    public static class MongoDbProvider
    {
        public static MongoDatabase Database
        {
            get
            {
                var connectionstring = dbSetting.Default.MONGOSupermarket_URI;
                string dbName = MongoUrl.Create(connectionstring).DatabaseName;
                MongoServer dbServer = MongoServer.Create(connectionstring);
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName, SafeMode.True);
                return dbConnection;
            }
        }

        public static void AddProducts (JsonReport jsonReport)
        {
            var productReports = Database.GetCollection<ProductReportJson>("ProductReports");
            var productList = productReports.AsQueryable<ProductReportJson>();
            var list = jsonReport.ProductReportsToList();
            foreach (var product in list)
            {
                int countWords = productList.AsQueryable<ProductReportJson>().Where(w => w.ProductId == product.ProductId).Count();
                var searched = productReports.AsQueryable<ProductReportJson>().FirstOrDefault(w => w.Name == product.Name.ToString());
                if (countWords > 0 && searched.Incomes != product.Incomes)
                {
                    UpdateProduct(product, productReports);
                }
                else if(countWords == 0)
                {
                    productReports.Insert<ProductReportJson>(product);
                } 
            }
    }

        public static List<ProductReportJson> MongoDBCollectionToList()
        {
            var productReports = Database.GetCollection<ProductReportJson>("ProductReports");
            var productList = productReports.AsQueryable<ProductReportJson>().ToList();
            return productList;
        }

        private static void UpdateProduct(ProductReportJson product, global::MongoDB.Driver.MongoCollection<ProductReportJson> productReports)
        {
            var searched = productReports.AsQueryable<ProductReportJson>().FirstOrDefault(w => w.Name == product.Name.ToString());
            if (searched != null)
            {
                var update = Update.Set("QuantitySold", product.QuantitySold.ToString()).Set("Incomes", product.Incomes.ToString());
                var query = Query.EQ("_id", searched.Id);
                productReports.Update(query, update);
            }
            else
            {
                throw new ArgumentNullException("This word is not exist");
            }
        }

        public static void AddVendorExpenses(List<VendorExpense> vendorExpense)
        {
            var productExpences = Database.GetCollection("VendorExpenses");
            var vendorexpensis =
            from item in vendorExpense
            group item by new { item.Vendor.Name } into r
            select new
            {
                VendorName = r.FirstOrDefault().Vendor.Name,
                TotalSum = r.Sum(v => v.MonthExpense)
            };

            foreach (var vendors in vendorexpensis)
            {
                productExpences.Insert(vendors);
            }
        }

    }
}
