using AjaxControlToolkit;
using CinemaColaborativos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CinemaColaborativos
{
    public partial class MovieAdministration : System.Web.UI.Page
    {
        HttpPostedFile fileToSave;
        List<pelicula> movieList = new List<pelicula>();
        MovieBusiness movie = new MovieBusiness();
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            movieList = movie.getAllMovies();
            AdminMovieRepeater.DataSource = movieList;
            AdminMovieRepeater.DataBind();
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

        protected void AdminMovieRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label movieID = (Label)e.Item.FindControl("MovieID");
                Label name = (Label)e.Item.FindControl("MovieName");
                Label gender = (Label)e.Item.FindControl("MovieGender");
                Label dates = (Label)e.Item.FindControl("Dates");
                Label duration = (Label)e.Item.FindControl("Duration");
                HiddenField description = (HiddenField)e.Item.FindControl("Description");
                description.Value = movieList.ElementAt(i).resumen;
                movieID.Text = movieList.ElementAt(i).id_pelicula.ToString();
                name.Text = movieList.ElementAt(i).nombre;
                gender.Text = movieList.ElementAt(i).genero;
                dates.Text = movieList.ElementAt(i).rango_fechas;
                duration.Text = movieList.ElementAt(i).duracion;
            }
            i++;
        }

        protected void AdminMovieRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditMovie"))
            {
                Label id = (Label)e.Item.FindControl("MovieID");
                Session["EDITMOVIE"] = movie.GetMovieByID(Convert.ToInt32(id.Text));
                Response.Redirect("EditMovie.aspx");
            }
            if (e.CommandName.Equals("DeleteMovie"))
            {
                Label id = (Label)e.Item.FindControl("MovieID");
                movie.DeleteMovie(Convert.ToInt32(id.Text));
                Response.Redirect("MovieAdministration.aspx");
            }

        }
    }
}