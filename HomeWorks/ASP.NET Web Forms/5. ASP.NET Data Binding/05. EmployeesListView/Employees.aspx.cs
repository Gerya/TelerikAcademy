using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _05.EmployeesListView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var context = new NorthwindEntities())
                {
                    var employees = context.Employees.ToList();

                    this.ListViewEmployees.DataSource = employees;
                    this.ListViewEmployees.DataBind();
                }
            }
        }
    }
}