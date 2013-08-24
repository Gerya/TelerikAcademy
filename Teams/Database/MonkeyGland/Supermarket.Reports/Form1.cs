using iTextSharp.text;
using iTextSharp.text.pdf;
using Supermarket.Data;
using System;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Supermarket.Data;
using Supermarket.Model;

namespace Supermarket.Reports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static SupermarketContext db;
        private void button1_Click(object sender, EventArgs e)
        {
            db = new SupermarketContext();

            var sortedSalesByDate =
                from s in db.Sales
                orderby s.Date
                select s;

            var totalSums =
            from p in sortedSalesByDate
            group p by p.Date into g
            select new { Category = g.Key, TotalSumPerDate = g.Sum(p => p.Sum) };


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/pdfExample.pdf";
            Document DC = new Document();
            FileStream FS = File.Create(path);
            PdfWriter.GetInstance(DC, FS);
            DateTime? currentDate = null;
            DC.Open();

            PdfPTable table = new PdfPTable(5);
            table.DefaultCell.PaddingTop = 2;
            table.DefaultCell.PaddingBottom = 10;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.MinimumHeight = 10;
            PdfPCell cell = new PdfPCell(new Phrase("Aggragated sales report", new Font(BaseFont.CreateFont((BaseFont.TIMES_ROMAN), BaseFont.CP1252, false), 20, 2, BaseColor.DARK_GRAY)));
            cell.Colspan = 5;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.MinimumHeight = 30;
            table.AddCell(cell);
            table.SpacingBefore = 10f;

            foreach (var row in sortedSalesByDate)
            {
                var product = row.Product.Name;
                var date = row.Date;
                var location = row.Location.Name;
                var quantity = row.Quantity;
                var unitPrice = row.UnitPrice;
                var sum = row.Sum;
                var sumPerDate =
                    from c in totalSums
                    where c.Category == date
                    select c.TotalSumPerDate;

                if (date != currentDate)
                {
                    if (currentDate == null)
                    {

                        currentDate = date;

                        PdfPCell currentReportDate = new PdfPCell(new Phrase(String.Format("{0:dd-MM-yyyy}", row.Date)));
                        currentReportDate.Colspan = 5;
                        currentReportDate.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(currentReportDate);
                        table.AddCell("Product");
                        table.AddCell("Quantity");
                        table.AddCell("Unit Price");
                        table.AddCell("Location");
                        table.AddCell("Sum");
                    }
                    else
                    {


                        PdfPCell currentTotalSum = new PdfPCell(new Phrase(String.Format("Total sum per date: {0:f}", sumPerDate.ToString())));
                        currentTotalSum.Colspan = 5;
                        currentTotalSum.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
                        table.AddCell(currentTotalSum);

                        currentDate = date;

                        PdfPCell currentReportDate = new PdfPCell(new Phrase(String.Format("{0:dd-MMM-yyyy} Total sum: {1}", row.Date, sumPerDate)));
                        currentReportDate.Colspan = 5;
                        currentReportDate.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(currentReportDate);
                        table.AddCell("Product");
                        table.AddCell("Quantity");
                        table.AddCell("Unit Price");
                        table.AddCell("Location");
                        table.AddCell("Sum");
                    }

                }
                table.AddCell(product);
                table.AddCell(quantity.ToString());
                table.AddCell(unitPrice.ToString());
                table.AddCell(location);
                table.AddCell(sum.ToString());
            }


            DC.Add(table);
            DC.Close();

        }
    }
}


