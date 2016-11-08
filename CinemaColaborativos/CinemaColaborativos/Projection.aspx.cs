using System;
using System.Web.UI.WebControls;
using CinemaColaborativos.Business;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using AjaxControlToolkit;

namespace CinemaColaborativos
{
    public partial class Projection : System.Web.UI.Page
    {
        ProjectionBusiness projBusiness = new ProjectionBusiness();
        MovieBusiness movieBusiness = new MovieBusiness();
        List<proyeccion> projectionList;
        pelicula movie = new pelicula();
        int i = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            movie = movieBusiness.GetMovieByID(Convert.ToInt32(Request.QueryString["value"]));
            SetMovieDetails(movie);
            projectionList = projBusiness.GetProjectionsWithMovieIDAsociated(Convert.ToInt32(Request.QueryString["value"]));
            ProjectionRepeater.DataSource = projectionList;
            ProjectionRepeater.DataBind();

        }

        private void SetMovieDetails(pelicula movie)
        {
            movieImg.Attributes.Add("src", movie.foto);
            movieName.InnerText = movie.nombre;
            description.InnerText = movie.resumen;
            gender.InnerText = "GENERO: " + movie.genero;
            duration.InnerText = "DURCIÓN: " + movie.duracion;
            dates.InnerText = "EN SALAS:" + movie.rango_fechas;
        }

        protected void ProjectionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl date = (HtmlGenericControl)e.Item.FindControl("projectionDate");
                date.InnerText = "FECHA: " + projectionList.ElementAt(i).fecha;
                HtmlGenericControl time = (HtmlGenericControl)e.Item.FindControl("projectionStartTime");
                time.InnerText = "HORA: " + projectionList.ElementAt(i).hora;
                HiddenField projectionID = (HiddenField)e.Item.FindControl("projectionID");
                HiddenField projectionState = (HiddenField)e.Item.FindControl("projectionState");
                projectionID.Value = projectionList.ElementAt(i).id_proyeccion.ToString();
                projectionState.Value = projectionList.ElementAt(i).estado_proyeccion.ToString();
                HtmlGenericControl theaterNumber = (HtmlGenericControl)e.Item.FindControl("theaterID");
                theaterNumber.InnerText = "NUMERO DE SALA: " + projectionList.ElementAt(i).sala_id_sala.ToString();
                HtmlGenericControl theaterType = (HtmlGenericControl)e.Item.FindControl("theaterType");
                theaterType.InnerText = "TIPO DE SALA: "+ projectionList.ElementAt(i).sala.tipo_sala;
            }
            i++;
        }

        protected void ProjectionRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("BuyTicket"))
            {
                HiddenField projectionState = (HiddenField)e.Item.FindControl("projectionState");
                bool state = Convert.ToBoolean(projectionState.Value);
                if (state)
                {
                    ModalPopupExtender popUp = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender1");
                    HiddenField id = (HiddenField)e.Item.FindControl("projectionID");
                    Session["IDPROJECCTION"] = id.Value;
                    popUp.Show();
                }
                else
                {
                    ModalPopupExtender errMessage = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender2");
                    sorryMessage.InnerText = "La pelicula que selecciono no está disponible. Sentimos las molestias. Por favor seleccione otra";
                    errMessage.Show();
                }
            }
        }

        protected void AcepptTicketBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("SeatReservation.aspx?value="+movie.id_pelicula+"&ticketAmount="+ticketQuantity.Value+"&ID="+Session["IDPROJECCTION"].ToString());
        }
    }
}