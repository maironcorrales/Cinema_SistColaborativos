using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class ProjectionAdministration : System.Web.UI.Page
    {
        pelicula movie = new pelicula();
        TheaterBusiness theaterBusiness = new TheaterBusiness();
        List<sala> list = new List<sala>();
        ProjectionBusiness projectionBusiness = new ProjectionBusiness();
        int i = 0;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MOVIE"] != null)
            {
                movie = (pelicula)Session["MOVIE"];
                movieProjection.InnerText = "Crear proyección para " + movie.nombre;
                PopulateTheaterSelection();
                list = theaterBusiness.GetAllTheaters();
                
            }
            else
                Response.Redirect("MovieAdministration.aspx");
        }

        private void PopulateTheaterSelection()
        {
            list = theaterBusiness.GetAllTheaters();
            foreach (var element in list)
            {
                theaterSelection.Items.Add(new ListItem(element.id_sala.ToString()));
            }
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

        protected void Save_ServerClick(object sender, EventArgs e)
        {
            proyeccion projection = new proyeccion();
            projection.fecha = eventDate_txt.Text;
            projection.hora = timepicker.Value;
            projection.estado_proyeccion = true;
            projection.pelicula_id_pelicula = movie.id_pelicula;
            projection.sala_id_sala = Convert.ToInt32(theaterSelection.SelectedItem.Text);
            if (projectionBusiness.CreateProjection(projection))
            {
                message.InnerText = "La Projección para la pelicula " + movie.nombre + ", ha sido creada con éxito.";
                ModalPopupExtender1.Show();
            }
            else
            {
                message.InnerText = "Ha ocurrido un error, por favor intentelo más tarde.";
                ModalPopupExtender1.Show();
            }
        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectionAdministration.aspx");
            i = 0;
        }

        protected void theaterSelection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}