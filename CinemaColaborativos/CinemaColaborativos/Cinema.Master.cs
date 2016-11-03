using CinemaColaborativos.Business;
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

        protected void AdminPane_ServerClick(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                usuario user = (usuario)Session["USER"];
                UserBusiness userBusiness = new UserBusiness();
                if (userBusiness.CheckUserType(user))
                    Response.Redirect("AdministrationPanel.aspx");
                else
                {
                    message.InnerText = "Su identificador de usuario indica que no es administrador del sistema. Si cree que es un error póngase en contacto con el administrador general.";
                    ModalPopupExtender1.Show();
                }
            }
            else
            {
                message.InnerText = "Debe registrarse como administrador y acceder a la aplicación para poder administrarla.";
                ModalPopupExtender1.Show();
            }
        }
    }
}