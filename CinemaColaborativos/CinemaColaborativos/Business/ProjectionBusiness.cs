using System.Collections.Generic;
using System.Linq;


namespace CinemaColaborativos.Business
{
    public class ProjectionBusiness
    {
        CinemaProjectEntities dbContex = new CinemaProjectEntities();

        public List<proyeccion> GetProjectionsWithMovieIDAsociated(int movieID)
        {
            List<proyeccion> projectionList = new List<proyeccion>();
            projectionList = dbContex.proyeccion.Where(b => b.pelicula_id_pelicula == movieID).ToList();
            return projectionList;
        }
    }
}