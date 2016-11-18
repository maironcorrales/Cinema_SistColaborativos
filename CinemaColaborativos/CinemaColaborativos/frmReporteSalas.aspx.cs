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
            int cantidadSillas = 0;
            Business.TheaterBusiness m = new Business.TheaterBusiness();
            List<sala> salas = new List<sala>();
            if (txtCantidadSillas.Text == "")
            {
                salas = m.consultarSala(DrpListTipo.SelectedValue, 0, chkEstado.Checked);
                resultado.DataSource = salas;
                resultado.DataBind();
                resultado.Visible = true;
            }
            else
            {
                if (int.TryParse(txtCantidadSillas.Text, out cantidadSillas))
                {
                    salas = m.consultarSala(DrpListTipo.SelectedValue, cantidadSillas, chkEstado.Checked);
                    resultado.DataSource = salas;
                    resultado.DataBind();
                    resultado.Visible = true;
                }
            }
            
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidadSillas.Text = "";
            DrpListTipo.SelectedIndex = 0;
            chkEstado.Checked= true;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReportes.aspx");
        }
    }
}