using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventsSystem.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.ModelBinding;
using Error_Handler_Control;

namespace EventsSystem.Admin
{
    public partial class EditEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PanelEventsDetails.Visible = false;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Event> GridViewEditEvents_GetData()
        {
            var context = new ApplicationDbContext();
            var date = DateTime.Now;
            var events = context.Events.Where(e => e.EventDate > date).OrderBy(e => e.EventDate);
            return events;
        }
            

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Event> GridViewEditEventsPast_GetData()
        {
            var context = new ApplicationDbContext();
            var date = DateTime.Now;
            var events = context.Events.Where(e=> e.EventDate <= date).OrderBy(e => e.EventDate);

            return events;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditEventsPast_UpdateItem(int id)
        {
            var context = new ApplicationDbContext();
            var updateEvent = context.Events.Find(id);

            if (updateEvent == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("This event is not found!");
                return;
            }

            TryUpdateModel(updateEvent);

            if (ModelState.IsValid)
            {
                //Literal errLiteral = (Literal)this.Master.FindControl("ErrorLiteral");
                try
                {
                    context.SaveChanges();
                    //errLiteral.Text = String.Empty;
                    context.Entry(updateEvent).State = EntityState.Modified;
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Event is modified");
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
                    //    //errLiteral.Text = (String.Join("<br/>", errorMessages));
                    //}
                    //else
                    //{
                    //    
                    //    //errLiteral.Text = ex.Message;
                    //}  
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditEventsPast_DeleteItem(int id)
        {
            var context = new ApplicationDbContext();
            var eventForDelete = context.Events.Find(id);
            if (eventForDelete == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("This event is not found!");
                return;
            }
            context.Events.Remove(eventForDelete);
            try
            {
                context.SaveChanges();
                this.GridViewEditEventsPast.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("The event is deleted");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditEventsCurrent_DeleteItem(int id)
        {
            var context = new ApplicationDbContext();
            var eventForDelete = context.Events.Find(id);
            if (eventForDelete == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("This event is not found!");
                return;
            }
            context.Events.Remove(eventForDelete);
            try
            {
                context.SaveChanges();
                this.GridViewEditEventsPast.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("The event is deleted");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditEventsCurrent_UpdateItem(int id)
        {
            var context = new ApplicationDbContext();
            var updateEvent = context.Events.Find(id);

            if (updateEvent == null)
            {
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
                    ErrorSuccessNotifier.AddSuccessMessage("The event is updated");
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

        protected void RadioButtonListEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = this.RadioButtonListEvents.SelectedValue;
           

            if (selected == "Future Events")
            {
                this.GridViewEditEventsCurrent.Visible = true;
                this.GridViewEditEventsPast.Visible = false;
                this.GridViewEditEventsCurrent.DataBind();
            }

            if (selected == "Past Events")
            {
                
                this.GridViewEditEventsCurrent.Visible = false;
                this.GridViewEditEventsPast.DataBind();
                this.GridViewEditEventsPast.Visible = true;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Event> ListViewDetailsEvent_GetData([Control("GridViewEditEventsCurrent")] int? id)
        {
            //this.PanelEventsDetails.Visible = true;
            var context = new ApplicationDbContext();

            return context.Events.Select(e => e).Where(e => e.Id == id);
        }

        protected void ButtonClose_Command(object sender, CommandEventArgs e)
        {
            this.PanelEventsDetails.Visible = false;
        }

        protected void GridViewEditEventsCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PanelEventsDetails.Visible = true;
        }
    }
}