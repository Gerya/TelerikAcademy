using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using EventsSystem.Models;
using Error_Handler_Control;

namespace EventsSystem.Account
{
    public partial class AllEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButonJoin_Click(object sender, CommandEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var eventId = Convert.ToInt32(e.CommandArgument);
                var ev = context.Events.Find(eventId);

                if (ev == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage("This event is not found!");

                    return;
                }

                var userId = Context.User.Identity.GetUserId();
                var currentUser = context.Users.Find(userId);

                if (currentUser == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage("This user is not found!");

                    return;
                }

                ev.Participants.Add(currentUser);

                try
                {
                    context.SaveChanges();
                    this.ListViewDetailsEvent.DataSource = context.Events.Where(eve => eve.Id == eventId).ToList();
                    this.ListViewDetailsEvent.DataBind();

                    ErrorSuccessNotifier.AddSuccessMessage("You've joined to event: " + ev.Title);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void LinkButtonDeleteEntry_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var eventId = Convert.ToInt32(e.CommandArgument);
            var ev = context.Events.Find(eventId);

            if (ev == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("This event is not found!");

                return;
            }

            var userId = User.Identity.GetUserId();
            var currentUser = context.Users.Find(userId);

            if (currentUser == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("This user is not found!");

                return;
            }

            using (context)
            {
                ev.Participants.Remove(currentUser);
                try
                {
                    context.SaveChanges();

                    this.ListViewDetailsEvent.DataSource = context.Events.Where(eve => eve.Id == eventId).ToList();
                    this.ListViewDetailsEvent.DataBind();

                    ErrorSuccessNotifier.AddSuccessMessage("You left the event: " + ev.Title);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        public IQueryable<Event> GridViewAllEvents_GetData()
        {
            var context = new ApplicationDbContext();
            var date = DateTime.Now;

            return context.Events.Where(e => e.EventDate >= date).OrderBy(e => e.EventDate);
        }

        //public Event ListViewDetailsEvent_GetData()
        //{
        //    var context = new ApplicationDbContext();
        //    var id = this.GridViewAllEvents.SelectedDataKey;
        //    if (id != null)
        //    {
        //        var eventId = Convert.ToInt32(id.Value);
        //        return context.Events.Where(e => e.Id == eventId);
        //    }
        //    return null;
        //}

        protected void GridViewAllEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new ApplicationDbContext();
            var id = this.GridViewAllEvents.SelectedDataKey;

            if (id == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("The event isn't selected");
            }

            if (id != null)
            {
                var eventId = Convert.ToInt32(id.Value);
                this.ListViewDetailsEvent.DataSource = context.Events.Where(ev => ev.Id == eventId).ToList();
                this.ListViewDetailsEvent.DataBind();
            }
        }
    }
}