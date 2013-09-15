using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Cookies
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            var pass = this.TextBoxPassword.Text;
            var user = this.TextBoxUsername.Text.ToLower();
            using(var context = new CookiesEntities())
            {
                var userEntity = context.Users.FirstOrDefault(u => u.UserName == user && u.Password == pass);
                if (userEntity != null)
                {
                    HttpCookie cookie = new HttpCookie("NickName", userEntity.NickName);
                    cookie.Expires = DateTime.Now.AddMinutes(1.0);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Hidden.aspx");
                }
            }
        }
    }
}