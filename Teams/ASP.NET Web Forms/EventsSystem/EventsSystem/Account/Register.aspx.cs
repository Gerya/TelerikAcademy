using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using EventsSystem.Models;
using System.IO;

namespace EventsSystem.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));

            ApplicationUser u = new ApplicationUser(userName) { UserName = userName, ProfilePicture = CreateDefaultImg()};
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);

            if (result.Success)
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                //manager.Roles.FindRoleByNameAsync("Registered")
                //    .ContinueWith(role =>
                //    {
                //manager.Roles.AddUserToRoleAsync(u.Id, role.Id.ToString());
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //});
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private byte[] CreateDefaultImg()
        {
            string strPhoto = MapPath("~/Content/default.png");
            FileStream fs = new FileStream(strPhoto, FileMode.Open, FileAccess.Read);

            Byte[] imgByte = new byte[fs.Length];

            fs.Read(imgByte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            return imgByte;
        }
    }
}