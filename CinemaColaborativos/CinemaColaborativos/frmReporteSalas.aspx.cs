using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmReporteSalas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int cantidadSillasDesde = 0;
            int cantidadSillasHasta = 0;
            Business.TheaterBusiness m = new Business.TheaterBusiness();
            List<sala> salas = new List<sala>();
            if (txtCantidadSillasHasta.Text == "0")
            {
                salas = m.consultarSala(DrpListTipo.SelectedValue, 0,0, chkEstado.Checked);
                resultado.DataSource = salas;
                resultado.DataBind();
                resultado.Visible = true;
            }
            else
            {
                if (int.TryParse(txtCantidadSillasDesde.Text, out cantidadSillasDesde) && int.TryParse(txtCantidadSillasHasta.Text, out cantidadSillasHasta))
                {
                    salas = m.consultarSala(DrpListTipo.SelectedValue, cantidadSillasDesde, cantidadSillasHasta, chkEstado.Checked);
                    resultado.DataSource = salas;
                    resultado.DataBind();
                    resultado.Visible = true;
                }
            }
            
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidadSillasDesde.Text = "";
            DrpListTipo.SelectedIndex = 0;
            chkEstado.Checked= true;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReportes.aspx");
        }
    }
}