using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class ProjectionOptions : System.Web.UI.Page
    {
        List<proyeccion> projectionList = new List<proyeccion>();
        int i = 0;
        ProjectionBusiness projectionBusiness = new ProjectionBusiness();
        pelicula movie = new pelicula();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MOVIE"] != null)
            {
                movie = (pelicula)Session["MOVIE"];
                projectionList = movie.proyeccion.ToList();
                ProjectionRepeater.DataSource = projectionList;
                ProjectionRepeater.DataBind();
                projectionTittle.InnerText = "Todas las proyecciones para " + movie.nombre;
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
                    Response.Redirect("ProjectionAdministration.aspx");
                }
                else
                {
                    Response.Redirect("ProjectionAdministration.aspx");
                }
            }
            if (e.CommandName.Equals("Delete"))
            {
                Label id = (Label)e.Item.FindControl("ProID");
                int idToSend = Convert.ToInt32(id.Text);
                if (projectionBusiness.DeleteProjection(idToSend))
                {
                    Response.Redirect("ProjectionAdministration.aspx");
                }
                else
                {
                    Response.Redirect("ProjectionAdministration.aspx");
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

        }
    }
}