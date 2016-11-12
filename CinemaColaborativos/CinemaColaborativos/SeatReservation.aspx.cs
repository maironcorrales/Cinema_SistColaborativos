using AjaxControlToolkit;
using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class SeatReservation : System.Web.UI.Page
    {
        int movieID;
        int projectionID;
        int userID;
        public int ticketNumber;
       
       
        List<reservacion> reservacionList = new List<reservacion>();
        Reservationbusiness reservation = new Reservationbusiness();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            reservacionList = reservation.getAllreservations();
            movieID = Convert.ToInt32(Request.QueryString["value"]);
            hi_counter.Value = Request.QueryString["ticketAmount"];
            ticketNumber = Convert.ToInt32(hi_counter.Value);
            projectionID = Convert.ToInt32(Request.QueryString["ID"]);
            usuario user = (usuario)Session["USER"];
            userID = user.id_usuario;
        }
        protected void AcepptReservationBtn_ServerClick(object sender, EventArgs e)
        {
            reservacion reservation = new reservacion();
            reservation.estado_reservacion = true;
            reservation.usuario_id_usuario = userID;
            reservation.proyeccion_id_proyeccion = projectionID;
            reservation.proyeccion_pelicula_id_pelicula = movieID;
           
            if (reservation.usuario_id_usuario != 0 && reservation.estado_reservacion  && reservation.proyeccion_id_proyeccion != 0 && reservation.proyeccion_pelicula_id_pelicula != 0)
            {
                Reservationbusiness reservationBusiness = new Reservationbusiness();
                if (reservationBusiness.CreateReservation(reservation))
                {
                   
                    Console.WriteLine("La reservacion se realizo con éxito.");
                    Response.Redirect("Checkout.aspx");
                }
                else
                {
                    Console.WriteLine("La reservación no se realizo. Intentelo más tarde.");
                  
                }
            }
            else
            {
                Console.WriteLine("error");
                
            }
            

            // Response.Redirect("SeatReservation.aspx?value=" + movie.id_pelicula + "&ticketAmount=" + ticketQuantity.Value + "&ID=" + Session["IDPROJECCTION"].ToString());
        }






    }
    }
