using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPeliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReportePeliculas.aspx");
        }

        protected void btnSalas_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReporteSalas.aspx");
        }

        protected void btnImpresionFactura_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReporteFactura.aspx");
        }

        protected void btnHistoricoPeliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReporteProyeccion.aspx");
        }
    }
}