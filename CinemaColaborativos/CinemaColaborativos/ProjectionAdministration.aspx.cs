using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class ProjectionAdministration : System.Web.UI.Page
    {
        pelicula movie = new pelicula();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MOVIE"] != null)
                movie = (pelicula)Session["MOVIE"];
            else
                Response.Redirect("MovieAdministration.aspx");
        }
    }
}