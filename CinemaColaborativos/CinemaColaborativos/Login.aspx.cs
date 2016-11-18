using CinemaColaborativos.Business;
using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace CinemaColaborativos
{
    public partial class Login : System.Web.UI.Page
    {
        public string Email_address = "";
        public string Google_ID = "";
        public string firstName = "";
        public string LastName = "";
        public string Client_ID = "";
        public string Return_url = "";
        public string BirthDay = "";
        public string Phone = "";
        public string nombre = "";
        UserBusiness userBusiness = new UserBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            fbLogin.NavigateUrl = "https://www.facebook.com/v2.8/dialog/oauth/?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Home.aspx&response_type=code&state=1&scope=email";
            if (!this.IsPostBack)
            {
                Client_ID = ConfigurationManager.AppSettings["google_clientId"].ToString();
                Return_url = ConfigurationManager.AppSettings["google_RedirectUrl"].ToString();
            }
            if (Request.QueryString["access_token"] != null)
            {

                String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString["access_token"].ToString();

                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                string b;

                /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
                using (StreamReader br = new StreamReader(stream))
                {
                    b = br.ReadToEnd();
                }

                b = b.Replace("id", "").Replace("email", "");
                b = b.Replace("given_name", "");
                b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
                b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
                b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");

                Array ar = b.Split(",".ToCharArray());
                for (int p = 0; p < ar.Length; p++)
                    ar.SetValue(ar.GetValue(p).ToString().Trim(), p);
        
                Email_address = ar.GetValue(1).ToString();
                Google_ID = ar.GetValue(0).ToString();
                firstName = ar.GetValue(4).ToString();
                LastName = ar.GetValue(5).ToString();
                BirthDay = ar.GetValue(6).ToString();
                nombre = ar.GetValue(3).ToString();
                Phone = ar.GetValue(7).ToString();
                AsignUser(Email_address, BirthDay, Phone,nombre);
                if (userBusiness.loginUser(Email_address).tipo_usuario ==0)
                {
                    Response.Redirect("AdministrationPanel.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
                
            }
        }

        private void AsignUser(string email,string birthday, string phone, string nombre)
        {
            
            
            if (userBusiness.loginUser(email) == null)
            {
                userBusiness.Createuser(email, birthday, phone,nombre);
                Session["USER"] = userBusiness.loginUser(email);
            }
            else
                Session["USER"] = userBusiness.loginUser(email); 
        }
    }
}