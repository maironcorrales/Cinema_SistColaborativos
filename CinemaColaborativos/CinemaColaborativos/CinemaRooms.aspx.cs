using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class CinemaRooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


               // salas = p.GetAllTheaters();

            }

        }
        protected void A1_ServerClick(object sender, EventArgs e)
        {


            //if(CB.createCinema(Sala.tipo_sala, Sala.numero_asientos, Sala.id_sala) == true)
            //{
            sala Sala = new sala();

            //int numeroAsientos = 0;
            //int.TryParse(idSala, out numeroAsientos);
            // Sala.id_sala = numeroAsientos.ToString;


            //if (CB.createCinema(roomType.Value, Convert.ToInt32(idSala.Value)))
            //{
            //    message.InnerText = "Nuevo sala creado con éxito";
            //    Sala.tipo_sala = roomType.Value;
            //    Sala.id_sala = Convert.ToInt32(idSala.Value);

            //}
            //else
            //{
            //    message.InnerText = "Fallo al crear nueva sala. Por favor intentelo más tarde. Si el problema persíste contacte al Web Master";




            //    // CB.createCinema(Sala.Equals != null) =
            //    //message.InnerText = "Nueva sala creado con éxito";
            //    //ModalPopupExtender1.Show();
            //}
        }
    }
}