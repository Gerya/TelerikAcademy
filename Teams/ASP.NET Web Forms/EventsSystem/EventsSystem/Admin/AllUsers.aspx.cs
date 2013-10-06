using EventsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Error_Handler_Control;

namespace EventsSystem.Admin
{
    public partial class AllUsers : System.Web.UI.Page
    {
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack){
                this.PanelDetailsEvent.Visible = false;
            }
            
        }

        public IQueryable<ApplicationUser> GridViewAllUsers_GetData()
        {
            var context = new ApplicationDbContext();
            var currentUserId = User.Identity.GetUserId();
            var users = context.Users.Where(u => u.Id != currentUserId && u.IsDeleted == false).OrderBy(usr => usr.Id);

            return users;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewAllUsers_UpdateItem(int id)
        {

        }

        protected void GridViewAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var id = this.GridViewAllUsers.SelectedDataKey.Value;
            //var context = new ApplicationDbContext();
            //var user = context.Users.Find(id);

            ////var events = user.Events.Where(ev => true).AsQueryable();
            ////context.Events.AddRange(user.Events).AsQueryable();
            //this.GridViewDetailsEvent.DataSource = context.Events.Where(ev => ev.Users == user);
            this.GridViewDetailsEvent.DataBind();
            this.GridViewDetailsEvent.Visible = true;
            this.PanelDetailsEvent.Visible = true;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewAllUsers_DeleteItem(string id)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.Find(id);

            if (user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("User doesn't exist");
            }

            var events = context.Events.ToList();

            foreach (Event ev in events)
            {
                ev.Participants.Remove(user);
            }

            //var userCreatedEvents = events.FindAll(x=> x.Creator.Id == user.Id);
            var userCreatedEvents = user.OwnEvents;

            user.IsDeleted = true;
            context.Events.RemoveRange(userCreatedEvents);

            try
            {
                context.SaveChanges();
                this.GridViewAllUsers.DataBind();
                this.PanelDetailsEvent.Visible = false;
                ErrorSuccessNotifier.AddSuccessMessage("User " + user.UserName + " is deleted!");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

        }

        protected void DeleteUserFromEvent(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            var eventId = Convert.ToInt32(lnkRemove.CommandArgument);
            var context = new ApplicationDbContext();
            string userId = this.GridViewAllUsers.SelectedDataKey.Value.ToString();
            var ev = context.Events.Find(eventId);

            if (ev == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Event doesn't exist");
                return;
            }

            var user = context.Users.Find(userId);

            if(user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("User doesn't exist");
                return;
            }

            user.Events.Remove(ev);

            try
            {
                context.SaveChanges();
                this.GridViewDetailsEvent.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage(ev.Title + " is removed from " + user.UserName);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            //var events = user.Events.ToList();
            //this.GridViewDetailsEvent.DataSource = events;
            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<EventsSystem.Models.Event> GridViewDetailsEvent_GetData()
        {
            var id = this.GridViewAllUsers.SelectedDataKey.Value;
            var context = new ApplicationDbContext();
            var user = context.Users.Find(id);

            //var events = user.Events.Where(ev => true).AsQueryable();
            var events = context.Events.AddRange(user.Events).AsQueryable();
            return events;
        }

        protected void ButtonClose_Command(object sender, CommandEventArgs e)
        {
            this.PanelDetailsEvent.Visible = false;
        }
    }
}