using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaColaborativos.Business
{
    public class TheaterBusiness
    {
        CinemaProjectEntities DbContext = new CinemaProjectEntities();
        public List<sala> GetAllTheaters()
        {
            return DbContext.sala.ToList();
        }

        //Retorna las películas que coninciden con los parámetros
        public List<sala> consultarSala(string tipo, int cantidad, bool estado)
        {
            List<sala> salas = new List<sala>();
            if (cantidad > 0)
            {
                return DbContext.sala.Where(m => m.tipo_sala == tipo && m.numero_asientos == cantidad && m.estado == estado).ToList();
            }
            else
            {
                return DbContext.sala.Where(m => m.tipo_sala == tipo && m.estado == estado).ToList();
            }
                
            
        }
    }
}