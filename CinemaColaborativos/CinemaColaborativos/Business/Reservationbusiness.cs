using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaColaborativos.Business
{

    public class Reservationbusiness
    {
        DB_A14118_colaborativosEntities reservationContex = new DB_A14118_colaborativosEntities();


        public List<reservacion> getAllreservations()
        {
            List<reservacion> reservationList = new List<reservacion>();
            reservationList = reservationContex.reservacion.ToList();
            return reservationList;
        }

        public reservacion GetReservationByID(int reservationID)
        {
            return reservationContex.reservacion.Where(r => r.id_reservacion == reservationID).FirstOrDefault();
        }
        public bool CreateReservation(reservacion reservation)
        {
            reservationContex.reservacion.Add(reservation);
            if (reservationContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public usuario GetUserID(String email)
        {
            return reservationContex.usuario.FirstOrDefault(u => u.correo == email);
        }


        public bool ActualizarValoracionReservacion(int idReservacion, int valoracion)
        {
            reservacion re = reservationContex.reservacion.Where(r => r.id_reservacion == idReservacion).FirstOrDefault();
            re.valoracion = valoracion;
            if (reservationContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

    }
}