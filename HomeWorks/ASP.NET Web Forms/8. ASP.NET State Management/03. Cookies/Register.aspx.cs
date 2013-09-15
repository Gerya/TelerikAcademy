using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Cookies
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            var pass = this.TextBoxPassword.Text;
            var user = this.TextBoxUsername.Text.ToLower();
            var nick = this.TextBoxNickName.Text;
            using (var context = new CookiesEntities())
            {
                var userEntity = context.Users.FirstOrDefault(u => u.UserName == user);
                if (userEntity == null)
                {
                    var newUser = new User
                    {
                        Password = pass,
                     UserName = user,
                        NickName = nick
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    HttpCookie cookie = new HttpCookie("NickName", newUser.NickName);
                    cookie.Expires = DateTime.Now.AddMinutes(1.0);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Hidden.aspx");
                }
            }
        }
    }
}