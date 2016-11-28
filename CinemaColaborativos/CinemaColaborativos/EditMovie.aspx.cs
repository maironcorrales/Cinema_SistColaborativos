using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaColaborativos
{
    public partial class EditMovie : System.Web.UI.Page
    {
        HttpPostedFile fileToSave;
        pelicula movie;
        MovieBusiness movieBusiness = new MovieBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            movie = (pelicula)Session["EDITMOVIE"];
            FillSpaces();
            Browse.Attributes.Add("onclick", "document.getElementById('" + ImageUploader.ClientID + "').click();");
            if (Session["NEWIMAGE"] == null)
                uploadedImage.Attributes.Add("src", movie.foto);
            else
                fileToSave = (HttpPostedFile)Session["NEWIMAGE"];
        }

        private void FillSpaces()
        {
            //List<string> dates = movieBusiness.SplitDate(movie.rango_fechas);
            movieName.Attributes.Add("placeholder", movie.nombre);
            movieGender.Value = movie.genero;
            timeOfMovie.Attributes.Add("placeholder", movie.duracion);
            fromDay.Value = "";
            fromYear.Value ="";
            ToDay.Value = "";
            toYear.Value = "";
            movieDescription.Attributes.Add("placeholder", movie.resumen);
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
                Session["NEWIMAGE"] = file;
                file.SaveAs(Server.MapPath(@"MovieImages/" + file.FileName));
                uploadedImage.Attributes.Add("src", "MovieImages/" + file.FileName);
            }
        }

        protected void SaveMovie_ServerClick(object sender, EventArgs e)
        {
            ValidateNull();
            movie.genero = movieGender.Value;
            movie.rango_fechas = fromDay.Value + "/" + fromYear.Value + " - " + ToDay.Value + "/" + toYear.Value;
            if (movieBusiness.updateMovie(movie))
                Response.Redirect("MovieAdministration.aspx");
            else
            {
                resultMessage.InnerText = "Ha ocurrido un error. Por favor intentelo más tarde.";
                ModalPopupExtender.Show();
            }

        }
        private void ValidateNull()
        {
            if (movieName.Value != "")
                movie.nombre = movieName.Value;
            if (movieDescription.Value != "")
                movie.resumen = movieDescription.Value;
            if (timeOfMovie.Value != "")
                movie.duracion = timeOfMovie.Value;
            if (fileToSave != null)
                movie.foto = "MovieImages/" + fileToSave.FileName;
        }
    }
     
}
