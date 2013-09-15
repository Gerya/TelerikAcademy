using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloPage
{
    public partial class HelloASP_NET : System.Web.UI.Page
    {
        protected void ButtonGreet_Click(object sender, EventArgs e)
        {
            this.TextBoxResponse.Text = string.Format("Hello, {0}", TextName.Value);
        }
    }
}