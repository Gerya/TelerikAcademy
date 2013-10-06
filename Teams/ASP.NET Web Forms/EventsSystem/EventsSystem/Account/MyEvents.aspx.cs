using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.Entity.Validation;
using EventsSystem.Models;
using Error_Handler_Control;

namespace EventsSystem.Account
{
    public partial class MyEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PanelParticipants.Visible = false;
        }

        public IQueryable<Event> GridViewCreatedEvents_GetData()
        {
            var context = new ApplicationDbContext();
            var id = User.Identity.GetUserId();

            return context.Events.Where(e => e.Creator.Id == id)
                .OrderBy(e => e.EventDate);
        }

        public void GridViewCreatedEvents_UpdateItem(int id)
        {
            var context = new ApplicationDbContext();
            var updateEvent = context.Events.Find(id);

            if (updateEvent == null)
            {
                //ModelState.AddModelError("", "This event is not found!");
                ErrorSuccessNotifier.AddErrorMessage("This event is not found!");

                return;
            }

            TryUpdateModel(updateEvent);

            if (ModelState.IsValid)
            {
                //Literal errLiteral = (Literal)this.Master.FindControl("ErrorLiteral");
                try
                {
                    //errLiteral.Text = String.Empty;
                    context.Entry(updateEvent).State = EntityState.Modified;
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Your event is modified");
                }
                catch (Exception ex)
                {
                    //if (ex is DbEntityValidationException)
                    //{
                    //    DbEntityValidationException validationEx =
                    //        (DbEntityValidationException)ex;
                    //    var errorMessages =
                    //        validationEx.EntityValidationErrors
                    //        .SelectMany(x => x.ValidationErrors)
                    //        .Select(x => x.ErrorMessage);
                    //    errLiteral.Text = (String.Join("<br/>", errorMessages));
                    //}
                    //else
                    //{
                    //    errLiteral.Text = ex.Message;
                    //}    

                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }     
            }
        }

        protected void GridViewCreatedEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ListViewDetailsEvent.Visible)
            {
                this.ListViewDetailsEvent.Visible = false;
            }

            var context = new ApplicationDbContext();
            var details = context.Events.Find(
                Convert.ToInt32(this.GridViewCreatedEvents.SelectedDataKey.Value));
            
            this.ListViewParticipants.DataSource = details.Participants;
            this.ListViewParticipants.DataBind();
            this.PanelParticipants.Visible = true;
        }

        protected void Kick_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var eventId = this.GridViewCreatedEvents.SelectedDataKey.Value;
            var eventRemoveUser = context.Events.Find(eventId);

            if (eventRemoveUser == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("The event wasn't found");

                return;
            }

            var user = context.Users.Find(e.CommandArgument);
            if (user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("The user wasn't found");

                return;
            }

            eventRemoveUser.Participants.Remove(user);

            try
            {
                context.SaveChanges();

                this.ListViewParticipants.DataSource = context.Events.Find(eventId).Participants;
                this.ListViewParticipants.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("The user is kicked");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Event> GridViewJoined_GetData()
        {
            var context = new ApplicationDbContext();
            var id = User.Identity.GetUserId();
            var user = context.Users.Find(id);

            if (user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("The user wasn't found");

                return null;
            }

            return context.Events.AddRange(user.Events).AsQueryable();
        }

        protected void GridViewJoined_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PanelParticipants.Visible)
            {
                this.PanelParticipants.Visible = false;
            }

            var eventId = Convert.ToInt32(this.GridViewJoined.SelectedDataKey.Value);
            var context = new ApplicationDbContext();
            var selectedEvent = context.Events.Where(ev => ev.Id == eventId);

            if (selectedEvent == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("There hasn't got such event");

                return;
            }

            this.ListViewDetailsEvent.DataSource = selectedEvent.ToList();
            this.ListViewDetailsEvent.DataBind();
            this.ListViewDetailsEvent.Visible = true;
        }

        protected void ButonLeave_Command(object sender, CommandEventArgs e)
        {
            var eventId = Convert.ToInt32( e.CommandArgument);
            var context = new ApplicationDbContext();
            var searchedEvent = context.Events.Find(eventId);
            var userId = User.Identity.GetUserId();
            var user = context.Users.Find(userId);

            if (searchedEvent == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("There hasn't got such event");

                return;
            }

            if (user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("There hasn't got such user");

                return;
            }

            user.Events.Remove(searchedEvent);
            searchedEvent.Participants.Remove(user);

            try
            {
                context.SaveChanges();
                this.GridViewJoined.DataBind();
                this.ListViewDetailsEvent.Visible = false;

                ErrorSuccessNotifier.AddSuccessMessage("You are removed from event");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void ButtonClosePanel_Command(object sender, CommandEventArgs e)
        {
            this.PanelParticipants.Visible = false;
        }

        protected void ButtonClose_Command(object sender, CommandEventArgs e)
        {
            this.ListViewDetailsEvent.Visible = false;
        }
    }
}