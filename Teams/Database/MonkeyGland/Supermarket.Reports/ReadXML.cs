using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Supermarket.Model;
using System.Data.Entity;
using Supermarket.Data;
using System.Globalization;

namespace Supermarket.Reports
{
    public static class ReadXML
    {
        public static List<VendorExpense> ReadFileXML(string path)
        {
            List<VendorExpense> readedVendorsExpense = new List<VendorExpense>();
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "sale"))
                    {
                        var newVendor = new VendorExpense();
                        var name = reader.GetAttribute("vendor");
                        var dbCobntext = new SupermarketContext();
                        var vendor = dbCobntext.Vendors.FirstOrDefault(x => x.Name == name);
                        newVendor.Vendor = vendor;
                        reader.Read();
                        reader.Read();
                        while ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "expenses"))
                        {
                            var month = reader.GetAttribute("month");
                            DateTime vendorMonth = DateTime.ParseExact(month, "MMM-yyyy", CultureInfo.InvariantCulture);
                            var sum = reader.ReadElementString();
                            newVendor.Date = vendorMonth;
                            newVendor.MonthExpense = decimal.Parse(sum, CultureInfo.InvariantCulture);
                            reader.Read();
                            readedVendorsExpense.Add(newVendor);
                            newVendor = new VendorExpense();
                            newVendor.Vendor = vendor;
                        }
                    }
                }
                return readedVendorsExpense;
            }
        }
    }
}
