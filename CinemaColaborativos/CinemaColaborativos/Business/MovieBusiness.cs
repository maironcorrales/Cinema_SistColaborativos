using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}