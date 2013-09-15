using System;
using System.Net;

namespace _01.BrowserTypeClientIPCheck
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelBrowserType.Text = Request.Browser.Type;
            this.LabelClientIP.Text = "Visitor IP: " + GetIpAddress() + "<br/>" + "Lan Ip Adress: " + GetLanIPAddress();

        }

        private string GetIpAddress()
        {
            string stringIpAddress;
            stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (stringIpAddress == null || stringIpAddress.ToLower() == "unknown")
            {
                stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            return stringIpAddress;
        }
        public string GetLanIPAddress()
        {
            //Get Host Name
            string stringHostName = Dns.GetHostName();
            //Get Ip Host Entry
            IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
            //Get Ip Address From The Ip Host Entry Address List
            IPAddress[] arrIpAddress = ipHostEntries.AddressList;
            return arrIpAddress[arrIpAddress.Length - 2].ToString();
        }
    }
}