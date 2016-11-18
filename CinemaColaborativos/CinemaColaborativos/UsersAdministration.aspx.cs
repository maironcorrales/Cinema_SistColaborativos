using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CinemaColaborativos.Business;

namespace CinemaColaborativos
{
    public partial class UsersAdministration : System.Web.UI.Page
    {
        UserBusiness userBusiness = new UserBusiness();
        List<usuario> adminList = new List<usuario>();
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){
                i = 0;
                adminList = userBusiness.GetAllAdmnistrators();
                AdminUserRepeater.DataSource = adminList;
                AdminUserRepeater.DataBind();
                if (Session["USER"] != null)
                {
                    usuario user = (usuario)Session["USER"];
                    MailToEdit.Attributes.Add("value", user.correo);
                    PhoneToEdit.Attributes.Add("value", user.telefono);
                    nombreModificar.Attributes.Add("value", user.nombre);
                }
            }
            
        }
        protected void AdminUserRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label nombreModificar = (Label)e.Item.FindControl("nombreModificar");
                nombreModificar.Text = adminList.ElementAt(i).nombre.ToString();
                Label userID = (Label)e.Item.FindControl("UserID");
                userID.Text = adminList.ElementAt(i).id_usuario.ToString();
                Label userMail = (Label)e.Item.FindControl("UserMail");
                userMail.Text = adminList.ElementAt(i).correo;
                Label phone = (Label)e.Item.FindControl("UserPhone");
                phone.Text = adminList.ElementAt(i).telefono;
                Label createDate = (Label)e.Item.FindControl("UserCreateDate");
                createDate.Text = "19/11/2016";
                bool state = adminList.ElementAt(i).estado;
                Label userState = (Label)e.Item.FindControl("UserState");
                if (state)
                    userState.Text = "Activo";
                else
                    userState.Text = "Inactivo";
            }
            i++;

        }

        protected void AdminUserRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            usuario user = new usuario();
            Label id = (Label)e.Item.FindControl("UserID");
            user.id_usuario = Convert.ToInt32(id.Text);
            Label mail = (Label)e.Item.FindControl("UserMail");
            user.correo = mail.Text;
            Label phone = (Label)e.Item.FindControl("UserPhone");
            user.telefono = phone.Text;
            Label date = (Label)e.Item.FindControl("UserCreateDate");
            user.fecha_nacimiento = date.Text;
            Label state = (Label)e.Item.FindControl("UserState");
            if (e.CommandName.Equals("ChangeState"))
            {
                if (state.Text.Equals("Activo"))
                    user.estado = false;
                else if (state.Text.Equals("Inactivo"))
                    user.estado = true;
                if (userBusiness.updateUser(user))
                {
                    message.InnerText = "El cambio de estado de usuario se ha realizado correctamente.";
                    ModalPopupExtender1.Show();
                }
                else
                {
                    message.InnerText = "El cambio de estado de usuario no se ha realizado. Intentelo de nuevo más tarde.";
                    ModalPopupExtender1.Show();
                }
            }
            if (e.CommandName.Equals("ChangeType"))
            {
                user.tipo_usuario = 1;
                if (userBusiness.updateUser(user))
                {
                    message.InnerText = "Se ha cambiado el tipo de usuario con éxito.";
                    ModalPopupExtender1.Show();
                }
                else
                {
                    message.InnerText = "No se ha realizado el cambio. Por favor intentelo más tarde.";
                    ModalPopupExtender1.Show();
                }
            }
        }

        protected void CreateUser_ServerClick(object sender, EventArgs e)
        {
            if (userBusiness.CreateAdministratorUser(mail.Value, DateTime.Now.ToShortDateString(), phonenumber.Value,nombre.Value))
            {
                message.InnerText = "Nuevo administrador creado con éxito";
                ModalPopupExtender1.Show();
            }
            else
            {
                message.InnerText = "Fallo al crear nuevo administrador. Por favor intentelo más tarde. Si el problema persíste contacte al Web Master";
                ModalPopupExtender1.Show();
            }
            if (Session["USER"] != null)
            {
                usuario user = (usuario)Session["USER"];
                MailToEdit.Attributes.Add("placeholder", user.correo);
                PhoneToEdit.Attributes.Add("placeholder", user.telefono);
                nombreModificar.Attributes.Add("placeholder", user.nombre);
            }
            i = 0;
            adminList = userBusiness.GetAllAdmnistrators();
            AdminUserRepeater.DataSource = adminList;
            AdminUserRepeater.DataBind();
            if (Session["USER"] != null)
            {
                usuario user = (usuario)Session["USER"];
                MailToEdit.Attributes.Add("value", user.correo);
                PhoneToEdit.Attributes.Add("value", user.telefono);
                nombreModificar.Attributes.Add("value", user.nombre);
            }
        }

        protected void SaveUser_ServerClick(object sender, EventArgs e)
        {
            usuario usuario= (usuario)Session["USER"];
            if (userBusiness.UpdateMailAndPhonenumber(PhoneToEdit.Value, usuario.id_usuario, nombreModificar.Value))
            {
                message.InnerText = "Usuario actualizado con éxito";
                ModalPopupExtender2.Show();
                Session["USER"] = userBusiness.GetUpdatedUser(usuario.id_usuario);
            }
            else
            {
                message.InnerText = "Ha ocurrido un error, por favor intentelo de nuevo más tarde";
                ModalPopupExtender2.Show();
            }
            i = 0;
            adminList = userBusiness.GetAllAdmnistrators();
            AdminUserRepeater.DataSource = adminList;
            AdminUserRepeater.DataBind();
            if (Session["USER"] != null)
            {
                usuario user = (usuario)Session["USER"];
                MailToEdit.Attributes.Add("value", user.correo);
                PhoneToEdit.Attributes.Add("value", user.telefono);
                nombreModificar.Attributes.Add("value", user.nombre);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrationPanel.aspx");
        }
    }
}