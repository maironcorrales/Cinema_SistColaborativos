using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class EditProjection : System.Web.UI.Page
    {
        ProjectionBusiness projectionBusiness = new ProjectionBusiness();
        TheaterBusiness theaterBusiness = new TheaterBusiness();
        List<sala> list = new List<sala>();
        int proID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateTheaterSelection();
            proID = Convert.ToInt32(Request.QueryString["ProID"]);
            
        }

        
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            eventDate_txt.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }

        protected void imgDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        private void PopulateTheaterSelection()
        {
            list = theaterBusiness.GetAllTheaters();
            foreach (var element in list)
            {
                theaterSelection.Items.Add(new ListItem(element.id_sala.ToString()));
            }
        }

        protected void btnAccept_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectionAdministration.aspx");
        }


        protected void SaveProjection_ServerClick(object sender, EventArgs e)
        {
            proyeccion pro = new proyeccion();
            pro.id_proyeccion = proID;
            pro.hora = timepicker.Value;
            pro.fecha = eventDate_txt.Text;
            pro.sala_id_sala = Convert.ToInt32(theaterSelection.SelectedItem.Text);
            if (projectionBusiness.UpdateProjection(pro))
            {
                message.InnerText = "Proyección Actulizada con éxito.";
                ModalPopupExtender1.Show();
            }
            else
            {
                message.InnerText = "Ha ocurrido un error. Por favor intentelo más tarde.";
                ModalPopupExtender1.Show();
            }
        }
    }
}