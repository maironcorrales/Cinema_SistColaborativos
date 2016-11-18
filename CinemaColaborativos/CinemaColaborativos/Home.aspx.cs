using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CinemaColaborativos.Business;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using CinemaColaborativos.Models;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace CinemaColaborativos
{
    public partial class Home : System.Web.UI.Page
    {
        MovieBusiness movie = new MovieBusiness();
        List<pelicula> movieList;
        int i = 0; // repeater counter
        int divCount =1;
        protected void Page_Load(object sender, EventArgs e)
        {
            movieList = movie.getAllMovies();
            TodaysMovieRepeater.DataSource = movieList;
            TodaysMovieRepeater.DataBind();
            if (Request.QueryString["code"] != null)
            {
                if(Session["USER"] == null)
                { 
                    var obj = GetFacebookUserData(Request.QueryString["code"]);
                    UserBusiness userBusiness = new UserBusiness();
                    if (userBusiness.loginUser(obj.ElementAt(0).email) == null)
                    {
                        userBusiness.Createuser(obj.ElementAt(0).email, obj.ElementAt(0).birthday, obj.ElementAt(0).phone, obj.ElementAt(0).first_name);
                        Session["USER"] = userBusiness.loginUser(obj.ElementAt(0).email);
                    }
                    else
                    {
                        Session["USER"] = userBusiness.loginUser(obj.ElementAt(0).email);
                    }
                }
            }
        }

        protected void TodaysMovieRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("movieDiv");
                if (divCount % 4 == 0)
                    div.Attributes.Add("class", "content-grid last-grid");
                else
                    div.Attributes.Add("class", "content-grid");
                HtmlImage img = (HtmlImage)e.Item.FindControl("movieImage");
                img.Attributes.Add("src", movieList.ElementAt(i).foto);
                HtmlGenericControl name = (HtmlGenericControl)e.Item.FindControl("name");
                name.InnerText = movieList.ElementAt(i).nombre;
                HiddenField id = (HiddenField)e.Item.FindControl("movieID");
                id.Value = movieList.ElementAt(i).id_pelicula.ToString();
            }
            i++;
            divCount++;
        }
    
        protected void TodaysMovieRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Book"))
            {
                if (Session["USER"] != null)
                {
                    HiddenField id = (HiddenField)e.Item.FindControl("movieID");
                    Response.Redirect("Projection.aspx?value=" + id.Value);
                }
                else
                {
                    ModalPopupExtender popUp = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender1");
                    message.InnerText = "Para poder acceder a la compra de tiquetes debe autenticarse. Si aun no lo ha hecho puede hacerlo ";
                    link.Attributes.Add("href", "Login.aspx");
                    link.InnerText = "aqui.";
                    popUp.Show();
                }
            }
        }

        protected List<FacebookUser.User> GetFacebookUserData(string code)
        {
            // Exchange the code for an access token
            Uri targetUri = new Uri("https://graph.facebook.com/oauth/access_token?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/Home.aspx&code=" + code);
            HttpWebRequest at = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            StreamReader str = new StreamReader(at.GetResponse().GetResponseStream());
            string token = str.ReadToEnd().ToString().Replace("access_token=", "");

            // Split the access token and expiration from the single string
            string[] combined = token.Split('&');
            string accessToken = combined[0];

            // Exchange the code for an extended access token
            Uri eatTargetUri = new Uri("https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&fb_exchange_token=" + accessToken);
            HttpWebRequest eat = (HttpWebRequest)HttpWebRequest.Create(eatTargetUri);

            StreamReader eatStr = new StreamReader(eat.GetResponse().GetResponseStream());
            string eatToken = eatStr.ReadToEnd().ToString().Replace("access_token=", "");

            // Split the access token and expiration from the single string
            string[] eatWords = eatToken.Split('&');
            string extendedAccessToken = eatWords[0];

            // Request the Facebook user information
            Uri targetUserUri = new Uri("https://graph.facebook.com/me?fields=first_name,last_name,gender,link,locale,email,birthday&access_token=" + accessToken);
            HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);

            // Read the returned JSON object response
            StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
            string jsonResponse = string.Empty;
            jsonResponse = userInfo.ReadToEnd();

            // Deserialize and convert the JSON object to the Facebook.User object type
            JavaScriptSerializer sr = new JavaScriptSerializer();
            string jsondata = jsonResponse;
            FacebookUser.User converted = sr.Deserialize<FacebookUser.User>(jsondata);

            // Write the user data to a List
            List<FacebookUser.User> currentUser = new List<FacebookUser.User>();
            currentUser.Add(converted);

            // Return the current Facebook user
            return currentUser;
        }
    }
}