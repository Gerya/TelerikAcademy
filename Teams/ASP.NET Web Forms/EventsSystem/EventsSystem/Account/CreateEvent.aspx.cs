using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventsSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.FriendlyUrls;
using System.ComponentModel.DataAnnotations;
using Error_Handler_Control;

namespace EventsSystem.Account
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCancelEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AllEvents");

            //using (var context = new ApplicationDbContext())
            //{
            //    var user = context.Users.FirstOrDefault();

            //    var events = user.OwnEvents.ToList();
            //}
        }

        //protected void Create_Click(object sender, EventArgs e)
        //{
        //    var newEvent = new Event
        //    {
        //        Title = this.TextBoxTitle.Text,
        //        Description = this.TextAreaDescription.InnerText,
        //        Location = this.TextBoxLocation.Text,
        //        EventDate = DateTime.Parse(this.TextBoxDateOfEvent.Text),
        //        CreatorId = User.Identity.GetUserId()
        //    };

        //    var context = new ApplicationDbContext();
        //    context.Events.Add(newEvent);
        //    context.SaveChanges();

        //    Response.Redirect("MyEvents");
        //}

        public void FormViewCreateEvent_InsertItem()
        {
            using (var context = new ApplicationDbContext())
            {
                var item = new Event();

                var CreatorId = User.Identity.GetUserId();

                //item.CreatorId = CreatorId;
                item.Creator = context.Users.FirstOrDefault(u => u.Id == CreatorId);

                this.TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    context.Events.Add(item);
                    context.SaveChanges();

                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    ErrorSuccessNotifier.AddSuccessMessage("Your new event is created!");

                    Response.Redirect("~/Account/MyEvents");
                }
            }
        }
    }
}