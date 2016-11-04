using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class Administration : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                usuario user = (usuario)Session["USER"];
                username.InnerText = user.correo + "!";
            }
        }
    }
}