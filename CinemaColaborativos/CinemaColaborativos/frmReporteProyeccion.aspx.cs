using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmReporteProyeccion : System.Web.UI.Page
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
            string nombrePelicula = ddlPeliculas.SelectedItem.ToString();
            DateTime fechaDesde = calDesde.SelectedDate;
            DateTime fechaHasta = calHasta.SelectedDate;
            if (fechaHasta.ToString() == "01/01/0001 12:00:00 a.m.")
            {
                fechaHasta = DateTime.ParseExact("2085-12-31 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
                dt = p.consultaProyeccion(nombrePelicula,fechaDesde,fechaHasta);
            int i = 0;
            string idPelicula = "";
            idPelicula = dt.Rows[0]["id_pelicula"].ToString();
            string horarios="";
            Image ima = new Image();
            DataTable resultados = new DataTable();
            resultados.Columns.Add("banner");
            resultados.Columns.Add("nombre", typeof(string));
            resultados.Columns.Add("horarios", typeof(string));
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (idPelicula == dt.Rows[i]["id_pelicula"].ToString())
                {

                    horarios += "* Número Sala " + dt.Rows[i]["id_sala"].ToString() + " tipo "+ dt.Rows[i]["tipo_sala"].ToString() + " Fecha y hora: " + dt.Rows[i]["fechaInicio"].ToString() ;

                }
                else
                {

                    resultados.Rows.Add(dt.Rows[i-1]["foto"], dt.Rows[i-1]["nombre"].ToString(), horarios);
                    idPelicula = dt.Rows[i]["id_pelicula"].ToString();

                    horarios = "* Número Sala " + dt.Rows[i]["id_sala"].ToString() + " tipo " + dt.Rows[i]["tipo_sala"].ToString() + " Fecha y hora: " + dt.Rows[i]["fechaInicio"].ToString();

                }

            }
            resultados.Rows.Add(dt.Rows[dt.Rows.Count - 1]["foto"], dt.Rows[dt.Rows.Count - 1]["nombre"].ToString(), horarios);
            ds.Tables.Add(resultados);
            resultado.DataSource = ds;
            resultado.DataBind();
            resultado.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReportes.aspx");
        }

        protected void ddlPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}