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
    }
}