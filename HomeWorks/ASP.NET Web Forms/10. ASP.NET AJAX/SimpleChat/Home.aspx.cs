using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChat
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListViewMessages_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            EntityDataSourceMessages.InsertParameters.Add(new Parameter("Timestamp", System.Data.DbType.DateTime2, DateTime.Now.ToString()));
        }

        protected void TimerTimeRefresh_Tick(object sender, EventArgs e)
        {
            ListViewMessages.DataBind();
        }
    }
}