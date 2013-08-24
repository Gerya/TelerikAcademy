using System;
using System.IO;
using System.Reflection;
using Ionic.Zip;
using System.Data.OleDb;
using System.Data;
using System.Data.Entity;
using Supermarket.Model;
using Supermarket.Data;
using System.Linq;


namespace Supermarket.Reports
{
    public class ExcelReader
    {
        public static void ReadExcelData()
        {
            var dbContext = new SupermarketContext();
            using (dbContext)
            {
                string[] subDirs;
                subDirs = Directory.GetDirectories(@"../../../../Reports/Sample-Sales-Extracted Files");
                foreach (var dir in subDirs)
                {
                    string[] files = Directory.GetFiles(dir);
                    //Console.WriteLine("Directory: " + dir);
                    //Console.WriteLine("Files:");
                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileName = new FileInfo(files[i]).Name;
                        int length =fileName.Length;
                        DateTime date = Convert.ToDateTime(fileName.Substring(0 + length - 15,11));
                        //Console.WriteLine("{0:dd-MM-yyyy}",date);
                        string currentFilePath = (dir + @"\" + new FileInfo(files[i]).Name);
                        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                         "Data Source=" + currentFilePath + ";Persist Security Info=False";

                        OleDbConnectionStringBuilder conString = new OleDbConnectionStringBuilder(connectionString);
                        conString.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

                        OleDbConnection dbConn = new OleDbConnection(conString.ConnectionString);

                        dbConn.Open();
                        using (dbConn)
                        {
                            DataTable dataSet = new DataTable();
                            string selectSql = @"SELECT * FROM [Sales$]";
                            OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, dbConn);
                            adapter.Fill(dataSet);

                            int rows = dataSet.Rows.Count;
                            string location = dataSet.Rows[0].ItemArray[0].ToString();
                            // Console.WriteLine("Company name: " + location);
                            for (int row = 2; row < rows - 2; row++)
                            {
                                Sale currentSale = new Sale();
                                Location currentLocation = new Location();
                                // currentLocation.Name = location;
                                dbContext.Locations.Add(currentLocation);
                                currentSale.Location = currentLocation;
                                int productID = Convert.ToInt32(dataSet.Rows[row].ItemArray[0]);
                                var product = from p in dbContext.Products
                                              where p.ID == productID
                                              select p;
                                Product currentProduct = product.First();
                                // Console.WriteLine("productID = "+productID);
                                
                                currentSale.Quantity = Convert.ToInt32(dataSet.Rows[row].ItemArray[1]);
                                currentSale.UnitPrice = Convert.ToDecimal(dataSet.Rows[row].ItemArray[2]);
                                currentSale.Sum = Convert.ToDecimal(dataSet.Rows[row].ItemArray[3]);
                                currentSale.Date = date;
                                currentSale.Product = currentProduct;
                                //Console.WriteLine(currentSale.Location.Name + " " + currentSale.Sum);
                                dbContext.Sales.Add(currentSale);
                                // dbContext.Products.Add(currentProduct);
                               dbContext.SaveChanges();
                            }

                        }
                    }

                }
            }
        }
    }
}
