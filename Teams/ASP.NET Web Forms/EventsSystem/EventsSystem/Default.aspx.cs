using EventsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace EventsSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var context = new ApplicationDbContext();

            this.LatestEvents.DataSource = context.Events
                .OrderBy(ev => ev.EventDate)
                .Where(ev => ev.EventDate > DateTime.Now)
                .Take(9)
                .ToList();
            this.LatestEvents.DataBind();

            if (((List<Event>)this.LatestEvents.DataSource).Count == 0)
            {
                this.NoEvents.Visible = true;
            }
        }
    }
}