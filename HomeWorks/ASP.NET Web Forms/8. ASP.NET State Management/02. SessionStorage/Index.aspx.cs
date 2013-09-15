using System;
using System.Collections.Generic;

namespace _02.SessionStorage
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["input"] != null)
            {
                LabelSessionStorage.Text = "In session storage have: " + String.Join(" ; ", (Session["input"] as List<string>));
            }
        }

        protected void ButtonAddText_Click(object sender, EventArgs e)
        {
            if (Session["input"] == null)
            {
                Session["input"] = new List<string>();
            }

            (Session["input"] as List<string>).Add(this.TextBoxInputFiled.Text);
            LabelSessionStorage.Text = "In session storage have: " + String.Join(" ; ", (Session["input"] as List<string>));
        }
    }
}