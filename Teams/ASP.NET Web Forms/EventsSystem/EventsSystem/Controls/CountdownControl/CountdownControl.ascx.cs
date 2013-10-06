using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventsSystem.UserControls
{
    public partial class CountdownControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.countdown.Attributes.Add("data-controlid", this.controlId);
        }
        protected void Page_Prerender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Testing"+this.ControlId,
                "animateCountdown('" + this.EndDate + "', '" + this.ControlId + "');", true);
        }

        private string endDate;
        public string controlId;

        public string EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
            }
        }

        public string ControlId
        {
            get
            {
                return this.controlId;
            }

            set
            {
                this.controlId = value;
            }
        }
    }
}