using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class MovieAdministration : System.Web.UI.Page
    {
        HttpPostedFile fileToSave;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            Browse.Attributes.Add("onclick", "document.getElementById('" + ImageUploader.ClientID + "').click();");
            if (Session["IMAGE"] == null)
                uploadedImage.Attributes.Add("src", "images/placeholder.gif");
            else
                fileToSave = (HttpPostedFile)Session["IMAGE"];
        }

        protected void UploadImage_ServerClick(object sender, EventArgs e)
        {
            if (!ImageUploader.HasFile)
            {
                resultMessage.InnerText = "Debe buscar y escoger una imagen primero.";
                ModalPopupExtender.Show();
            }
            else
            {
                HttpPostedFile file = ImageUploader.PostedFile;
                Session["IMAGE"] = file;
                file.SaveAs(Server.MapPath(@"MovieImages/" + file.FileName));
                uploadedImage.Attributes.Add("src", "MovieImages/" + file.FileName);
            }
        }

        protected void SaveMovie_ServerClick(object sender, EventArgs e)
        {
            pelicula movie = new pelicula();
            movie.nombre = movieName.Value;
            movie.duracion = movieTime.Value;
            movie.genero = movieGender.Value;
            movie.rango_fechas = fromDay.Value + "/" + fromYear.Value + " - " + ToDay.Value + "/" + toYear.Value;
            movie.resumen = movieDescription.Value;
            movie.foto = "MovieImages/" + fileToSave.FileName;
            if (movie.nombre != null && movie.duracion != null && movie.genero != null && movie.rango_fechas != null && movie.foto != null)
            {
                MovieBusiness movieBusiness = new MovieBusiness();
                if (movieBusiness.CreateMovie(movie))
                {
                    resultMessage.InnerText = "Pélicula creada con éxito.";
                    ModalPopupExtender.Show();
                }
                else
                {
                    resultMessage.InnerText = "La pélicula no ha sido creada debido a que se ha producido un error. Intentelo más tarde.";
                    ModalPopupExtender.Show();
                }
            }
            else
            {
                resultMessage.InnerText = "Debe llenar todos los espacios requeridos";
                ModalPopupExtender.Show();
            }
            EraseFields();

        }

        private void EraseFields()
        {
            movieName.Value = "";
            movieTime.Value = "";
            movieGender.Value = "";
            movieDescription.Value = "";
            fromDay.Value = "";
            fromYear.Value = "";
            ToDay.Value = "";
            toYear.Value = "";
            fileToSave = null;
            uploadedImage.Attributes.Add("src", "images/placeholder.gif");
        }
    }
}