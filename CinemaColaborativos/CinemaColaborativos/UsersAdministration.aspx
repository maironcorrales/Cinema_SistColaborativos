<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="UsersAdministration.aspx.cs" Inherits="CinemaColaborativos.UsersAdministration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/tableStyle.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="contact-content">
		
			<!---contact-->
<div class="main-contact">
		 <h3 class="head">Administración de Usuarios</h3>
		 <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <div>
                        <h2>Crear Nuevo Usuario Administrador</h2><br />
                     </div>
                     <div class="form-group">
                         <br />
                         <br />
                         <input runat="server" id="nombre" type="text" placeholder="Nombre" class="form-control" style="width:80%;"  /><br />
                         <input runat="server" id="mail" type="text" placeholder="Correo" class="form-control" style="width:80%;"  /> <br />
                         <input runat="server" id="phonenumber" type="text" placeholder="Teléfono" class="form-control" style="width:80%;"  />
                         <a  runat="server" id="CreateUser" class="button play-icon popup-with-zoom-anim" style="width:20%;text-align:center;" onserverclick="CreateUser_ServerClick">Crear</a>
                         <asp:Button ID="processbtn" runat="server" Style="visibility:hidden"/>
                     </div>
                     
				  </div>
				  <div class="col-md-6 contact-right">
                      <h2>Modificar datos de Usuario Actual</h2>
                      <p>&nbsp;</p>
                      <br />
                      <br />
                         <input runat="server" id="nombreModificar" type="text" placeholder="Nombre" class="form-control" style="width:80%;"  /><br />
                      <input runat="server" id="MailToEdit" type="text" class="form-control" style="width:80%;" disabled /> <br />
                      <input runat="server" id="PhoneToEdit" type="text" class="form-control" style="width:80%;"  />
                      <a class="button play-icon popup-with-zoom-anim" runat="server" id="SaveUser" onserverclick="SaveUser_ServerClick" style="width:20%;text-align:center;">Guardar</a>
                      <asp:Button ID="saveProcessBtn" runat="server" Style="visibility:hidden"/>	 
				 </div>
				 <div class="clearfix"></div>
	     </div>
</div>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
             CancelControlID="btnCancel"
             TargetControlID="processbtn"
             PopupControlID="Panel1"
             Drag="true"
             BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
             CancelControlID="btnCancel"
             TargetControlID="saveProcessBtn"
             PopupControlID="Panel1"
             Drag="true"
             BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="Panel1" Style="display: none" CssClass="modalPopup" align="center" runat="server">
             <p runat="server" id="message"></p>
             <div class="clearfix"> </div>
             <input class="button play-icon popup-with-zoom-anim" id="btnCancel" type="button" value="Aceptar" />
        </asp:Panel>
       
            <div class="error-content">
                <div class="error-404 text-center">
				<p>Usuarios Administradores</p>
                    <table cellspacing="0">
                    <tr>
                        <th style="width:20%">Nombre de usuario</th>
                        <th style="width:10%">Id de Usuario</th>
                        <th style="width:20%">Correo</th>
                        <th style="width:20%">Número Telefónico</th>
                        <th style="width:20%">Fecha de Creación</th>
                        <th style="width:20%">Estado</th>
                        <th style="width:20%">Cambiar Estado</th>
                        <th style="width:20%">Cambiar Tipo</th>

                    </tr>
                        
                        <asp:Repeater id="AdminUserRepeater" runat="server" OnItemDataBound="AdminUserRepeater_ItemDataBound" OnItemCommand="AdminUserRepeater_ItemCommand">
                        <ItemTemplate>
                            <tr runat="server">
                                <td><asp:Label runat="server" ID="nombreModificar"/></td>
                                <td><asp:Label runat="server" ID="UserID"/></td>
                                <td><asp:Label runat="server" ID="UserMail"/></td>
                                <td><asp:Label runat="server" ID="UserPhone"/></td>
                                <td><asp:Label runat="server" ID="UserCreateDate"/></td>
                                <td><asp:Label runat="server" ID="UserState"/></td>
                                <td><asp:LinkButton runat="server" CssClass="button play-icon popup-with-zoom-anim" CommandName="ChangeState" Text="Cambiar Estado"></asp:LinkButton></td>
                                <td><asp:LinkButton runat="server" CssClass="button play-icon popup-with-zoom-anim" CommandName="ChangeType" Text="Cambiar Tipo"></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        </asp:Repeater>                   
                </table>
			        <br />
                    <br />
                    
                    <br />
			</div>	
            </div>

       
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRegresar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnRegresar_Click"  PostBackUrl="~/UsersAdministration.aspx" Text="Regresar" />
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
                height: 160px;
            }
        </style>

</asp:Content>
