using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class AllMovieOptions : System.Web.UI.Page
    {
        MovieBusiness movie = new MovieBusiness();
        List<pelicula> movieList;
        int i = 0; // repeater counter
        int divCount = 1;
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
                HiddenField id = (HiddenField)e.Item.FindControl("movieID");
                id.Value = movieList.ElementAt(i).id_pelicula.ToString();
            }
            i++;
            divCount++;
        }

        protected void TodaysMovieRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                HiddenField id = (HiddenField)e.Item.FindControl("movieID");
                Session["EDITMOVIE"] = movie.GetMovieByID(Convert.ToInt32(id.Value));
                Response.Redirect("EditMovie.aspx");
            }
            if (e.CommandName.Equals("Delete"))
            {
                HiddenField id = (HiddenField)e.Item.FindControl("movieID");
                movie.DeleteMovie(Convert.ToInt32(id.Value));
                Response.Redirect("MovieAdministration.aspx");
            }
            if (e.CommandName.Equals("Projections"))
            {
                HiddenField id = (HiddenField)e.Item.FindControl("movieID");
                int idV = Convert.ToInt32(id.Value);
                Session["MOVIE"] = movie.GetMovieByID(idV);
                Response.Redirect("ProjectionAdministration.aspx");
            }
        }
    }
}