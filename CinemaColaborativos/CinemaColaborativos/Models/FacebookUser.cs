using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaColaborativos.Models
{
    public class FacebookUser
    {
        public class User
        {
            public string id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string birthday { get; set; }
            public string phone { get; set; }
        }
    }
}