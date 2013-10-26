using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CheckBoxRequired_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxAccept.Checked;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            
            if (IsLogonValid() && IsPersonalInfoValid() && IsAddressInfoValid())
            {
                Response.Write("success");
                this.form1.Visible = false;
            }
        }

        protected bool IsLogonValid()
        {
            this.Page.Validate("LogonInfo");
            if (this.Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsPersonalInfoValid()
        {
            this.Page.Validate("PersonalInfo");
            if (this.Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsAddressInfoValid()
        {
            this.Page.Validate("AddressInfo");
            if (this.Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}