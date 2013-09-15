using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.EmployeesSPA
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonBack.Visible = false;

            if (!Page.IsPostBack)
            {
                using (var context = new NorthwindEntities())
                {
                    var employees = context.Employees.Select(emp => new
                    {
                        Id = emp.EmployeeID,
                        FullName = emp.FirstName + " " + emp.LastName
                    })
                    .ToList();

                    this.GridViewEmployees.DataSource = employees;
                    this.GridViewEmployees.DataBind();
                }
            }
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32(this.GridViewEmployees.SelectedDataKey.Value);

            using (var context = new NorthwindEntities())
            {
                var employees = context.Employees.Where(emp => emp.EmployeeID == employeeId).ToList();
                this.FormViewDetails.DataSource = employees;
                this.FormViewDetails.DataBind();

                this.GridViewEmployees.Visible = false;
                this.FormViewDetails.Visible = true;
                this.ButtonBack.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.GridViewEmployees.Visible = true;
            this.FormViewDetails.Visible = false;
            this.ButtonBack.Visible = false;
        }
    }
}