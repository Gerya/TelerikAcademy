using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetExecutingAssembly
{
    public partial class GetExecutingAssembly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBoxHello.Text = Assembly.GetExecutingAssembly().Location;
        }
    }
}