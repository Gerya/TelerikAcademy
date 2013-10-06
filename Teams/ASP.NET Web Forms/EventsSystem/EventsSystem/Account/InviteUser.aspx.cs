using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Error_Handler_Control;
using EventsSystem.Models;
using System.Net;

namespace EventsSystem.Account
{
    public partial class InviteUser: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.PanelUsersResult.Visible = false;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var searchedUser = this.TextBoxUserSearch.Text.ToString();
            if (searchedUser == null || searchedUser == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("Search do not work for empty text");

                return;
            }
            else
            {
                this.PanelUsersResult.Visible = true;
                this.GridViewUsersResult.DataBind();

            }

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<ApplicationUser> GridViewUsersResult_GetData()
        {
            var context = new ApplicationDbContext();
            var searchedUser = this.TextBoxUserSearch.Text.ToString();
            var searchedUsers = from user in context.Users
                                where user.UserName.Contains(searchedUser) && user.IsDeleted == false
                                select user;

            return searchedUsers;
        }

        protected void GridViewUsersResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new ApplicationDbContext();
            var curentUser = User.Identity.GetUserName();
            var selectedUser = this.GridViewUsersResult.SelectedDataKey.Value.ToString();

            if (curentUser == selectedUser)
            {
                ErrorSuccessNotifier.AddErrorMessage("You cannot invite yourself");

                return;
            }

            this.TextBoxInvitedUser.Text = selectedUser;
            var id = User.Identity.GetUserId();
            this.DropDownListEvents.DataSource = context.Events.Where(evnt => evnt.Creator.Id == id).ToList();
            this.DropDownListEvents.DataBind();
            this.PanelInviteUser.Visible = true;
        }

        protected void ButonIvate_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            var context = new ApplicationDbContext();
            var invite = new Invite();

            invite.CreatedDate = DateTime.Now;

            var status = context.Status.FirstOrDefault(x=> x.InviteStatus == "New");

            invite.InviteStatus = status;

            var invitationSenderId = User.Identity.GetUserId();
            var invitationSender = context.Users.FirstOrDefault(x => x.Id == invitationSenderId);

            invite.Sender = invitationSender;
            invite.Message = this.TextBoxMessage.Text;

            var recipient = context.Users.FirstOrDefault(u => u.UserName == this.TextBoxInvitedUser.Text);

            invite.Recipient = recipient;

            var eventId = Convert.ToInt32(this.DropDownListEvents.SelectedItem.Value);
            var selectedEvent = context.Events.FirstOrDefault(ev => ev.Id == eventId);

            invite.Event = selectedEvent;
            context.Invites.Add(invite);

            try
            {
                context.SaveChanges();

                ErrorSuccessNotifier.ShowAfterRedirect = true;
                ErrorSuccessNotifier.AddSuccessMessage(string.Format("Your invitation to {0} is sent", recipient.UserName));                              
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            if (ErrorSuccessNotifier.ShowAfterRedirect)
            {
                Response.RedirectPermanent("~/Account/InviteUser"); 
            }
        }

        protected void LinkButtonCancel_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            this.PanelInviteUser.Visible = false;
        }
    }
}