using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CinemaColaborativos.Business;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

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
                HtmlGenericControl resume = (HtmlGenericControl)e.Item.FindControl("resume");
                resume.InnerText = movieList.ElementAt(i).resumen;
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
                    Response.Redirect("Projection.aspx?value" + id.Value);
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
    }
}