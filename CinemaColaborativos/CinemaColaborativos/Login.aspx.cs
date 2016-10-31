using System;
using System.Configuration;

namespace CinemaColaborativos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fbLogin.NavigateUrl = "https://www.facebook.com/v2.8/dialog/oauth/?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Home.aspx&response_type=code&state=1&scope=email";
            
        }
    }
}