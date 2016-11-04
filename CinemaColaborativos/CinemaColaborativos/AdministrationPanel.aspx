<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="AdministrationPanel.aspx.cs" Inherits="CinemaColaborativos.AdministrationPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-content">
		
			<!---contact-->
<div class="main-contact">
		 <h3 class="head">Opciones de Administración</h3>
		 <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <a href="UsersAdministration.apsx">
                        <img src="images/users.png" style="width:15%;height:15%;"/> <br />
                         Administradores
                     </a>
                     <br />
                     <br />
                     <a href="Report.apsx">
                        <img src="images/encuesta.png" style="width:15%;height:15%;"/><br />
                         Reportes
                     </a>
				  </div>
				  <div class="col-md-6 contact-right">
					 <p>Este espacio está diseñado para que el administrador controle el contenido de la aplicación. Por lo tanto se le provee al mismo un espacio de administración de todas las áreas del cinema, de esta forma es sencillo administar y censar el contenido del sitio. Se espera que no tenga se encuentren complicaciones al hacerlo. Caso contrario contacte al web master <a style="color:red;" href="ContactWebMaster.aspx">aquí.</a></p>
				 </div>
				 <div class="clearfix"></div>
	     </div>
</div>
        </div>
</asp:Content>
