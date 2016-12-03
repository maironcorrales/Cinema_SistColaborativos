<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="CinemaRooms.aspx.cs" Inherits="CinemaColaborativos.CinemaRooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contact-content">
         <div class="main-contact">
         <h3 class="head">Administración de salas</h3>
               
                          <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <div>
                        <h2>Crear Sala</h2><br />
                         </div>
                     <div class="form-group">
                         <br />
                         <br />Ingrese el id de la sala:
                         &nbsp;<input runat="server" id="idSala" type="text" placeholder="IdSala" class="form-control" style="width:80%;"  />
                         <br />Ingrese el tipo de sala:
                         <div>
                         <select class="form-control" id="roomType" runat="server" tabindex="1" style="width:60%;">
                            <option selected="selected" value=""></option>
                            <option value="3D">3D</option>
                            <option value="2D">2D</option>
                            <option value="IMAX">IMAX</option>
                            <option value="4DX">4DX</option>

                         </select><br />
                         <div>
                              <a  runat="server" class="button play-icon popup-with-zoom-anim" id="A1" onserverclick="A1_ServerClick" style="width:20%;text-align:center;" >Crear sala</a>
                         <asp:Button ID="ButtonCreate" runat="server" Style="visibility:hidden"/>
                          </div class="col-md-6 contact-left">
                     <div>
                            <h2>Eliminar Sala</h2>
                             <br />Seleccione la sala a eliminar:
                          <div>
                                    
                         
                         <asp:Button ID="ButtonDelete" runat="server" Style="visibility:hidden"/>
                                        <asp:Panel ID="Panel1" Style="display: none" CssClass="modalPopup" align="center" runat="server">
             <p runat="server" id="message"></p>
             <div class="clearfix"> </div>
             <input class="button play-icon popup-with-zoom-anim" id="btnCancel" type="button" value="Aceptar" />
        </asp:Panel>
                                   
                 <select class="form-control" id="Select1" runat="server" tabindex="1" style="width:80%;">

                              </select><br />

                              <a  runat="server" class="button play-icon popup-with-zoom-anim" id="A2" onserverclick="A1_ServerClick" style="width:20%;text-align:center;" >Eliminar sala</a>
      

        </style>
</asp:Content>