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
        ProjectionBusiness projectionBusiness = new ProjectionBusiness();
        List<sala> list = new List<sala>();
        List<proyeccion> projectionList = new List<proyeccion>();
        int i = 0;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MOVIE"] != null)
            {
                movie = (pelicula)Session["MOVIE"];
                movieProjection.InnerText = "Crear proyección para " + movie.nombre;
                PopulateTheaterSelection();
                list = theaterBusiness.GetAllTheaters();
                projectionList = movie.proyeccion.ToList();
                ProjectionRepeater.DataSource = projectionList;
                ProjectionRepeater.DataBind();
            }
            else
                Response.Redirect("MovieAdministration.aspx");
            projectionTittle.InnerText = "Todas las proyecciones para " + movie.nombre;
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

        protected void ProjectionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label proID = (Label)e.Item.FindControl("ProID");
                Label proDate = (Label)e.Item.FindControl("ProDate");
                Label proTime = (Label)e.Item.FindControl("ProTime");
                Label proTheater = (Label)e.Item.FindControl("ProTheater");
                proID.Text = projectionList.ElementAt(i).id_proyeccion.ToString();
                proDate.Text = projectionList.ElementAt(i).fecha;
                proTime.Text = projectionList.ElementAt(i).hora;
                proTheater.Text = projectionList.ElementAt(i).sala_id_sala.ToString();
                LinkButton changeState = (LinkButton)e.Item.FindControl("changeStatus");
                if (projectionList.ElementAt(i).estado_proyeccion == true)
                    changeState.Text = "Activo";
                else
                    changeState.Text = "Inactivo";
            }
            i++;
        }

        protected void ProjectionRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("ChangeStatus"))
            {
                Label id = (Label)e.Item.FindControl("ProID");
                int idToSend = Convert.ToInt32(id.Text);
                if (projectionBusiness.ChangeStatus(idToSend))
                {
                    message.InnerText = "Estado cambiado con éxito.";
                    ModalPopupExtender1.Show();
                }
                else
                {
                    message.InnerText = "Ha ocurrido un error. Intentelo más tarde.";
                    ModalPopupExtender1.Show();
                }
            }
            if (e.CommandName.Equals("Delete"))
            {
                Label id = (Label)e.Item.FindControl("ProID");
                int idToSend = Convert.ToInt32(id.Text);
                if (projectionBusiness.DeleteProjection(idToSend))
                {
                    message.InnerText = "Se ha eliminado la projección correctaente.";
                    ModalPopupExtender1.Show();
                }
                else
                {
                    message.InnerText = "Ha ocurrido un error. Intentelo más tarde.";
                    ModalPopupExtender1.Show();
                }
            }
            if (e.CommandName.Equals("Edit"))
            {
                Label id = (Label)e.Item.FindControl("ProID");
                Response.Redirect("EditProjection.aspx?ProID=" + id.Text);
            }
        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ProjectionAdministration.aspx");
            i = 0;
        }
    }
}