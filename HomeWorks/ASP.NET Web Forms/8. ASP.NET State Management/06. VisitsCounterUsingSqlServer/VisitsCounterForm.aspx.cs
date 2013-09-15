using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.VisitsCounterUsingSqlServer
{
    public partial class VisitsCounterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new VisitsCounterEntities())
            {
                var visitsCounter = context.Visits.FirstOrDefault(v => v.Id == "COUNTS");
                if (visitsCounter == null)
                {
                    // error
                }

                visitsCounter.Value++;
                context.SaveChanges();

                Response.Clear();

                Bitmap generatedImage = new Bitmap(200, 200);
                using (generatedImage)
                {
                    Graphics gr = Graphics.FromImage(generatedImage);
                    using (gr)
                    {
                        gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);
                        gr.DrawString(visitsCounter.Value.ToString(), new Font(FontFamily.GenericSansSerif, 18), Brushes.Yellow, new PointF(80, 82));

                        // Set response header and write the image into response stream
                        Response.ContentType = "image/gif";

                        //Response.AppendHeader("Content-Disposition",
                        //    "attachment; filename=\"Financial-Report-April-2013.gif\"");

                        generatedImage.Save(Response.OutputStream, ImageFormat.Gif);
                    }
                }
            }
        }
    }
}