using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.JavaScriptInjection
{
    public partial class SamplePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Enter the following script in the textbox in IE/Mozilla/Opera (Chrome will not execute it)
            // and you will see that the "clicks" value is lost
            // <script>window.onload = function () { var viewState = document.getElementById("__VIEWSTATE");viewState.parentNode.removeChild(viewState);}</script>
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            Response.Write(this.TextBoxInput.Text);
        }

        protected void ButtonClickMe_Click(object sender, EventArgs e)
        {
            if (this.ViewState["clicks"] == null)
            {
                this.ViewState["clicks"] = 1;
            }
            else
            {
                int clicks = (int)this.ViewState["clicks"];
                this.ViewState["clicks"] = ++clicks;
            }

            this.LabelClicks.Text = this.ViewState["clicks"].ToString() + " clicks";
        }
    }
}