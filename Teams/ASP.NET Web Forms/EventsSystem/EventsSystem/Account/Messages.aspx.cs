using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;
using EventsSystem.Models;
using Microsoft.AspNet.Identity;
using System.Web.ModelBinding;
using EventsSystem.Helpers;

namespace EventsSystem.Account
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelMessagesDetails.Visible = false;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Invite> GridViewAllMessages_GetData([ViewState("OrderBy")]String orderBy = null)
        {
            var context = new ApplicationDbContext();
            var currentId = User.Identity.GetUserId();
            var user = context.Users.Find(currentId);

            var invites = context.Invites.Include("Sender").Include("InviteStatus").Include("Event")
                .Where(inv => inv.Recipient.Id == user.Id)
                .AsQueryable();

            if (orderBy != null)
            {
                switch (this.SortDirection)
                {
                    case SortDirection.Ascending:
                        invites = invites.OrderByDescending(orderBy);
                        break;
                    case SortDirection.Descending:
                        invites = invites.OrderBy(orderBy);
                        break;
                    default:
                        invites = invites.OrderByDescending(orderBy);
                        break;
                }
            }
            return invites;
        }

        protected void GridViewAllMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new ApplicationDbContext();
            var inviteId = Convert.ToInt32(this.GridViewAllMessages.SelectedDataKey.Value);
            this.ListViewDetails.DataSource = context.Invites.Include("Sender").Include("Event").Where(inv => inv.Id == inviteId).ToList();
            this.ListViewDetails.DataBind();
            this.PanelMessagesDetails.Visible = true;
            var invite = context.Invites.Find(inviteId);
            var status = context.Status.FirstOrDefault(s => s.InviteStatus == "Readed");
            invite.InviteStatus = status;
            context.SaveChanges();
            this.GridViewAllMessages.DataBind();
        }

        protected void LinkButtonCancel_Command(object sender, CommandEventArgs e)
        {
            this.PanelMessagesDetails.Visible = false;
        }

        protected void ButonJoin_Command(object sender, CommandEventArgs e)
        {
            var userId = User.Identity.GetUserId();
            var context = new ApplicationDbContext();
            var user = context.Users.Find(userId);
            var eventId = Convert.ToInt32(e.CommandArgument);
            var eventToJoin = context.Events.Find(eventId);
            eventToJoin.Participants.Add(user);
            try
            {
                context.SaveChanges();
                this.PanelMessagesDetails.Visible = false;
                ErrorSuccessNotifier.AddSuccessMessage("You successfully joined " + eventToJoin.Title);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewAllMessages_DeleteItem(int id)
        {
            var context = new ApplicationDbContext();
            var message = context.Invites.Find(id);
            try
            {
                context.Invites.Remove(message);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("You successfully delete message.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void TimerTimeRefresh_Tick(object sender, EventArgs e)
        {
            this.GridViewAllMessages.DataBind();
        }

        protected void GridViewAllMessages_Sorting(object sender, GridViewSortEventArgs e)
        {
            e.Cancel = true;
            ViewState["OrderBy"] = e.SortExpression;
            this.GridViewAllMessages.DataBind();
        }

        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["sortdirection"] == null)
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["sortdirection"] == SortDirection.Ascending)
                {
                    ViewState["sortdirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            set
            {
                ViewState["sortdirection"] = value;
            }
        }
    }
}