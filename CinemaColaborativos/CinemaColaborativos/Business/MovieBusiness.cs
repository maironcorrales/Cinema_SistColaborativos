using System.Collections.Generic;
using System.Linq;

namespace CinemaColaborativos.Business
{

    public class MovieBusiness
    {
        DB_A14118_colaborativosEntities movieContext = new DB_A14118_colaborativosEntities();
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

        public bool CreateMovie(pelicula movie)
        {
            movieContext.pelicula.Add(movie);
            if (movieContext.SaveChanges() == 1)
                return true;
            else
                return false;

        }

        //public List<string> SplitDate(string date)
        //{
        //    List<string> dateArray = new List<string>();
        //    string[] array = date.Split('/',' ','-',' ');
        //    foreach(var element in array) 
        //        dateArray.Add(element);
        //    dateArray.RemoveAt(2);
        //    dateArray.RemoveAt(2);
        //    return dateArray;
        //}

        public bool DeleteMovie(int id)
        {
            var result = movieContext.pelicula.FirstOrDefault(m => m.id_pelicula == id);
            movieContext.pelicula.Remove(result);
            if (movieContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool updateMovie(pelicula movie)
        {
            var result = movieContext.pelicula.FirstOrDefault(m => m.id_pelicula == movie.id_pelicula);
            if (result != null)
            {
                result.nombre = movie.nombre;
                result.genero = movie.genero;
                result.duracion = movie.duracion;
                result.foto = movie.foto;
                result.resumen = movie.resumen;
            }
            if (movieContext.SaveChanges() == 1)
                return true;
            else
                return false;
        }
        //Retorna las películas que coninciden con los parámetros
        public List<pelicula> consultarPelicula(string genero, string fecha,string nombre)
        {
            List<pelicula> movieList = new List<pelicula>();
            if (genero =="Género" && fecha =="/ - /" && nombre =="")
            {
                return getAllMovies();
                
            }

            if (genero == "Género" && fecha != "/ - /" &&  nombre != "")
            {
                return movieContext.pelicula.Where(m => m.rango_fechas == fecha && m.nombre.Contains(nombre)).ToList();
            }

            if (genero == "Género" && fecha == "/ - /" && nombre != "")
            {
                return movieContext.pelicula.Where(m => m.nombre.Contains(nombre)).ToList();
            }

            if (genero != "Género" && fecha == "/ - /" && nombre != "")
            {
                return movieContext.pelicula.Where(m =>m.genero == genero && m.nombre.Contains(nombre)).ToList();
            }
            if (genero != "Género" && fecha == "/ - /" && nombre == "")
            {
                return movieContext.pelicula.Where(m => m.genero == genero && m.nombre.Contains(nombre)).ToList();
            }

            if (genero == "Género" && fecha != "/ - /" && nombre == "")
            {
                return movieContext.pelicula.Where(m => m.rango_fechas.Contains(fecha)).ToList();
            }

            if (genero == "Género" && fecha == "/ - /" && nombre != "")
            {
                return movieContext.pelicula.Where(m =>  m.nombre.Contains(nombre)).ToList();
            }

            if (genero != "Género" && fecha != "/ - /" && nombre != "")
            {
                return movieContext.pelicula.Where(m => m.rango_fechas == fecha && m.nombre.Contains(nombre) && m.genero == genero).ToList();
            }
            else {
                return movieContext.pelicula.Where(m => m.rango_fechas == fecha && m.nombre.Contains(nombre) && m.genero == genero).ToList();
            }
        }
    }
}