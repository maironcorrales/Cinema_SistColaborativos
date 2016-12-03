using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaColaborativos.Business
{
    public class CinemaBusiness
    {
        DB_A14118_colaborativosEntities DbContext = new DB_A14118_colaborativosEntities();
        public bool createCinema(String tipoSala, int idRoom)
        {

            sala cinemaRoom = new sala();
            int numeroAsientos = 100;
            cinemaRoom.numero_asientos = numeroAsientos;
            cinemaRoom.tipo_sala = tipoSala;
            cinemaRoom.id_sala = idRoom;
            cinemaRoom.estado = true;

            DbContext.sala.Add(cinemaRoom);
            DbContext.SaveChanges();
            if (DbContext.SaveChanges() == 1)
                return true;
            else
                return false;

        }

        public bool deleteCinemaRoom(int id)
        {
            sala cinemaRoom = new sala();
            cinemaRoom = DbContext.sala.Where(p => p.id_sala == id).FirstOrDefault();
            DbContext.sala.Remove(cinemaRoom);
            if (DbContext.SaveChanges() == 1)
                return true;
            else
                return false;

        }
        public bool ChangeStatus(int id)
        {
            sala CR = new sala();
            CR = DbContext.sala.Where(p => p.id_sala == id).FirstOrDefault();
            if (CR.estado == true)
                CR.estado = false;
            else
                CR.estado = true;
            if (DbContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }
}
