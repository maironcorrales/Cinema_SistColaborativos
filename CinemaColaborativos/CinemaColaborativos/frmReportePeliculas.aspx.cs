using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmReportePeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
         
            string fecha = "";
            string genero = DrpListGenero.SelectedValue;
            string nombre = txtNombre.Text;
            List<pelicula> movieList = new List<pelicula>();

            Business.MovieBusiness m = new Business.MovieBusiness();
            movieList=m.consultarPelicula(genero,fecha,nombre);
            resultado.DataSource = movieList;
            resultado.DataBind();
            resultado.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void resultado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReportes.aspx");
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            DrpListGenero.SelectedIndex = 0;
            txtNombre.Text = "";

        } 
    }

}