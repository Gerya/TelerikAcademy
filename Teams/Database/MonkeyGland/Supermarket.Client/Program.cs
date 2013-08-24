using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data;
using Supermarket.Model;
using System.Data.Entity;
using Supermarket.Data.Migrations;
using Supermarket.Reports;
using System.IO;
using Supermarket.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using System.Windows.Forms;


namespace Supermarket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //// only the first time

           // FromMySqlNeverAgain();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());

            /// run separately or it will be slow :)

            //Zipper.UnzipFiles();
            //ExcelReader.ReadExcelData();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            var dbCobntext = new SupermarketContext();


            XmlReport.GenerateXml("../../../../GeneratedReports/xmlSales.xml");

            JsonReport jsonReport = new JsonReport(dbCobntext);
            jsonReport.GetProductsReport(@"../../../../GeneratedReports/productsReport.json");
            jsonReport.GenerateJsonFilesForEachProduct(@"../../../../GeneratedReports/ProductReportsForMongo/");
            MongoDbProvider.AddProducts(jsonReport);
            var ProductsFRomMongo = MongoDbProvider.MongoDBCollectionToList();

            ExcelReport excelReport = new ExcelReport(dbCobntext);
            excelReport.GenerateVendorTotalReport("n", ProductsFRomMongo);

            var vendorExpenses = ReadXML.ReadFileXML("../../../../Reports/Vendors-Expenses.xml");
            MongoDbProvider.AddVendorExpenses(vendorExpenses);


            Console.WriteLine();
        }




        private static void FromMySqlNeverAgain()
        {
            var dbcontext = new SupermarketContext();

            var mySqlContx = new SupermarketModel();
            using (mySqlContx)
            {
                var products = mySqlContx.Products.OrderBy(e => e.ID).ToList();
                var vendors = mySqlContx.Vendors.ToList();
                var mesuares = mySqlContx.Measures.ToList();
                using (dbcontext)
                {

                    foreach (var mesuare in mesuares)
                    {
                        var newMeasure = new Measure()
                        {
                            ID = mesuare.ID,
                            Name = mesuare.Name
                        };
                        dbcontext.Measures.Add(newMeasure);

                    }

                    foreach (var vendor in vendors)
                    {
                        var newVendor = new Vendor()
                        {
                            ID = vendor.ID,
                            Name = vendor.Name
                        };
                        dbcontext.Vendors.Add(newVendor);
                    }


                    foreach (var product in products)
                    {
                        var some = new Product
                        {
                            BasePrice = product.BasePrice,
                            Measure_ID = product.Measure_ID,
                            Name = product.Name,
                            Vendor_ID = product.Vendor_ID,
                        };
                        dbcontext.Products.Add(some);
                    }

                    dbcontext.SaveChanges();
                }


            }
        }
    }
}
