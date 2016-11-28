<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="MovieAdministration.aspx.cs" Inherits="CinemaColaborativos.MovieAdministration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/tableStyle.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contact-content">
         <div class="main-contact">
         <h3 class="head">Administración de películas</h3>
             <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <div>
                        <h2>Crear Película</h2><br />
                     </div>
                     <div class="form-group">
                         <input runat="server" id="movieName" type="text" placeholder="Nombre de la Película" class="form-control" style="width:80%;" required /> <br />
                         <input runat="server" id="movieTime" type="text" placeholder="Duración en Minutos" class="form-control" style="width:80%;" required /><br />
                         <select class="form-control" id="movieGender" runat="server" tabindex="1" style="width:80%;">
                            <option selected="selected" value="">Género</option>
                            <option value="Acción">Acción</option>
                            <option value="Horror">Horror</option>
                            <option value="Aventura">Aventura</option>
                            <option value="Animación">Animación</option>
                            <option value="Suspenso">Suspenso</option>
                            <option value="Fantasía">Fantasía</option>
                            <option value="Comedia">Comedia</option>
                            
                            <option value="Cine Independiente">Cine Independiente</option>
                         </select><br />
                         <textarea runat="server" id="movieDescription" class="form-control" placeholder="Descripción de la película" style="width:80%;"></textarea>

                         <a  runat="server" class="button play-icon popup-with-zoom-anim" id="SaveMovie" onserverclick="SaveMovie_ServerClick" style="width:20%;text-align:center;" >Crear</a>
                         <asp:Button ID="processbtn" runat="server" Style="visibility:hidden"/>
                     </div>
                     
				  </div>
				  <div class="col-md-6 contact-right">
                      <h2>Foto de la película</h2><br />
                      <img runat="server" id="uploadedImage" style="width:100%;height:100%;" />
                      <a class="button play-icon popup-with-zoom-anim" runat="server" id="Browse" style="width:20%;text-align:center;">Buscar</a>
                      <a class="button play-icon popup-with-zoom-anim" id="UploadImage" runat="server" onserverclick="UploadImage_ServerClick" style="width:20%;text-align:center;">Subir Foto</a>
                      <asp:FileUpload id="ImageUploader" runat="server" style="display:none;"/>
                      <asp:Button ID="saveProcessBtn" runat="server" Style="visibility:hidden"/>	 
				 </div>
                 <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server"
                        TargetControlID="processbtn"
                        CancelControlID="btnAccept"
                        PopupControlID="Panel2"
                        Drag="true"
                        BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>
                 <asp:Panel ID="Panel2" Style="display:none" CssClass="modalPopup" align="center" runat="server">
                                        <p runat="server" id="resultMessage"></p>
                                        <hr />
                                        <a id="btnAccept"  class="button play-icon popup-with-zoom-anim" style="width:30%; text-align:center; height:30%;"  runat="server">Aceptar</a>
                                    </asp:Panel>
				 <div class="clearfix"></div>
                 <a class="button play-icon popup-with-zoom-anim" style="width:20%;text-align:center;" href="AllMovieOptions.aspx">Peliculas</a>
	     </div>    
         </div>
     </div>
    <style type="text/css">
            .modalBackground {
                background-color: Black;
                filter: alpha(opacity=90);
                opacity: 0.8;
            }

            .modalPopup {
                background-color: #FFFFFF;
                border-width: 3px;
                border-style: solid;
                border-color: black;
                padding-top: 10px;
                padding-left: 10px;
                width: 300px;
                height: 180px;
            }
        </style>
</asp:Content>
