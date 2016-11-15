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

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Business.ProjectionBusiness p = new Business.ProjectionBusiness();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            int numeroFactura = 0;
            if (int.TryParse(txtNumeroFactura.Text, out numeroFactura))
            {
                dt = p.consultaFactura(numeroFactura);
            }
            else
            {
                dt = p.consultaFactura(0);
            }
            ds.Tables.Add(dt);
            resultado.DataSource = ds;
            resultado.DataBind();
            resultado.Visible = true;

        }

       
    }

  
  
}