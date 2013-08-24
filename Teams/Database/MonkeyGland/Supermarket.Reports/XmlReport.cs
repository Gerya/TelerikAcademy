using System;
using System.Xml;
using System.Text;
using Supermarket.Data;
using System.Linq;
using System.Data.Entity;

namespace Supermarket.Reports
{
    public static class XmlReport
    {
        public static void GenerateXml(string fileName)
        {
            
            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                var dbContext = new SupermarketContext();
                using (dbContext)
                {
                    foreach (var vendorData in dbContext.Vendors)
                    {
                        writer.WriteStartElement("sale");
                        writer.WriteAttributeString("vendor", vendorData.Name);

                        var data =
                            from vendor in dbContext.Vendors
                            join product in dbContext.Products
                            on vendor.ID equals product.Vendor_ID
                            join sale in dbContext.Sales
                            on product.ID equals sale.Product.ID
                            where vendor.ID == vendorData.ID
                            select new
                            {
                                SaleDate = sale.Date,
                                TotalSales = sale.Sum
                            };

                        var result =
                            from item in data
                            group item by new { item.SaleDate } into r

                            select new
                            {
                                SaleDate = r.FirstOrDefault().SaleDate,
                                TotalSum = r.Sum(v => v.TotalSales)
                            };

                        foreach (var resultItem in result)
                        {
                            WriteSummary(writer, resultItem.SaleDate.ToString(), resultItem.TotalSum.ToString());
                        }

                        writer.WriteEndElement();

                    }

                    //for (int i = 0; i < length; i++)
                    //{
                    //    writer.WriteStartElement("sale");
                    //    writer.WriteAttributeString("vendor", date);
                    //    for (int i = 0; i < length; i++)
                    //    {

                    //    }
                    //    writer.WriteEndElement();
                    //}
                }

                writer.WriteEndDocument();
            }
            //Console.WriteLine("Document {0} created.", fileName);
        }

        private static void WriteSummary(XmlWriter writer, string date, string sum)
        {
            writer.WriteStartElement("summary");
            writer.WriteAttributeString("date", date);
            writer.WriteAttributeString("total-sum", sum);
            writer.WriteEndElement();
        }
    }
}
