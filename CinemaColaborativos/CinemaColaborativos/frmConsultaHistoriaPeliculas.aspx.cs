using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmConsultaHistoriaPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Business.ProjectionBusiness p = new Business.ProjectionBusiness();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            dt = p.consultaFactura(0,"","");
            ds.Tables.Add(dt);
            resultado.DataSource = ds;
            resultado.DataBind();
            resultado.Visible = true;
        }

        protected void resultado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void itemSelected(object sender, EventArgs e)
        {
            Business.Reservationbusiness r = new Business.Reservationbusiness();
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlNew = (DropDownList)resultado.Rows[row.RowIndex].FindControl("ddlValoraciones");
            string abc = ddlNew.SelectedValue;
            string proyeccion = resultado.Rows[row.RowIndex].Cells[4].Text;
            int idReservacion = 0;
            int valor = 0;
            if (int.TryParse(abc, out valor))
            {
                if (int.TryParse(proyeccion, out idReservacion))
                {
                    r.ActualizarValoracionReservacion(idReservacion, valor);
                }
            }
        }

        protected void cargarDatos(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void resultado_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}