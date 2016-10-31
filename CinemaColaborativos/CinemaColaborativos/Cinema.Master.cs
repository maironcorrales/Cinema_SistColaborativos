using System;

namespace CinemaColaborativos
{
    public partial class Cinema : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                usuario user = (usuario)Session["USER"];
                username.InnerText = user.correo+"!";
            }
                
        }

    }
}