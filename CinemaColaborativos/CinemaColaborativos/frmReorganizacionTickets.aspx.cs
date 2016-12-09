using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class frmReorganizacionTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Business.ProjectionBusiness p = new Business.ProjectionBusiness();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            usuario user = (usuario)Session["USER"];

            dt = p.consultaPeliculaPorUsuario(user.id_usuario);
            ds.Tables.Add(dt);
            resultado.DataSource = ds;
            resultado.DataBind();
            resultado.Visible = true;
        }
    }
}