using System.Collections.Generic;
using System.Linq;

namespace CinemaColaborativos.Business
{

    public class MovieBusiness
    {
        CinemaProjectEntities movieContext = new CinemaProjectEntities();
        public List<pelicula> getAllMovies()
        {
            List<pelicula> movieList = new List<pelicula>();
            movieList = movieContext.pelicula.ToList();
            return movieList;
        }

        public pelicula GetMovieByID(int movieID)
        {
            return movieContext.pelicula.Where(m => m.id_pelicula == movieID).FirstOrDefault();
        }
    }
}