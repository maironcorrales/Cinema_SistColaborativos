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

        public proyeccion GetProjectionByID(int id)
        {
            return dbContex.proyeccion.Where(p => p.id_proyeccion == id).FirstOrDefault();
        }

        public bool CreateProjection(proyeccion projection)
        {
            dbContex.proyeccion.Add(projection);
            if (dbContex.SaveChanges()==1)
                return true;
            else
                return false;
        }

        public bool ChangeStatus(int id)
        {
            proyeccion pro = new proyeccion();
            pro = dbContex.proyeccion.Where(p => p.id_proyeccion == id).FirstOrDefault();
            if (pro.estado_proyeccion == true)
                pro.estado_proyeccion = false;
            else
                pro.estado_proyeccion = true;
            if (dbContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool DeleteProjection(int id)
        {
            proyeccion pro = new proyeccion();
            pro = dbContex.proyeccion.Where(p => p.id_proyeccion == id).FirstOrDefault();
            dbContex.proyeccion.Remove(pro);
            if (dbContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool UpdateProjection(proyeccion projection)
        {
            proyeccion pro = dbContex.proyeccion.Where(p => p.id_proyeccion == projection.id_proyeccion).FirstOrDefault();
            pro.fecha = projection.fecha;
            pro.hora = projection.hora;
            pro.sala_id_sala = projection.sala_id_sala;
            if (dbContex.SaveChanges() == 1)
                return true;
            else
                return false;
        }
    }
}