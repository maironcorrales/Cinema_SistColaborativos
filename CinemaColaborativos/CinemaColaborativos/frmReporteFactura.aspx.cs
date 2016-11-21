using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmReporteFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<pelicula> peliculas = new List<pelicula>();
                Business.MovieBusiness p = new Business.MovieBusiness();
                peliculas = p.getAllMovies();
                int i = 0;
                for (i = 0; i < peliculas.Count; i++)
                {
                    ddlPeliculas.Items.Add(peliculas[i].nombre);
                }
                ddlPeliculas.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

                Business.ProjectionBusiness p = new Business.ProjectionBusiness();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
            string pelicula = ddlPeliculas.SelectedValue;
            if (pelicula == "Seleccione una película")
            {
                pelicula = "";
            }
                int numeroFactura = 0;
                if (int.TryParse(txtNumeroFactura.Text, out numeroFactura))
                {
                    dt = p.consultaFactura(numeroFactura,txtCorreoElectronico.Text, pelicula);
                }
                else
                {
                    dt = p.consultaFactura(0, txtCorreoElectronico.Text, pelicula);
                }
                ds.Tables.Add(dt);
                resultado.DataSource = ds;
                resultado.DataBind();
                resultado.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroFactura.Text = "";
            txtCorreoElectronico.Text = "";
            ddlPeliculas.SelectedIndex=0;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReportes.aspx");
        }
    }

  
  
}