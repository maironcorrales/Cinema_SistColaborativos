<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="AdministrationPanel.aspx.cs" Inherits="CinemaColaborativos.AdministrationPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-content">
		
			<!---contact-->
<div >
		 <h3 class="head">Opciones de Administración</h3>
         <p class="head">&nbsp;</p>
					 <h2>Este espacio está diseñado para que el administrador controle el contenido de la aplicación. Por lo tanto se le provee al mismo un espacio de administración de todas las áreas del cinema, de esta forma es sencillo administar y censar el contenido del sitio. Se espera que no tenga se encuentren complicaciones al hacerlo. Caso contrario contacte al web master <a style="color:red;" href="ContactWebMaster.aspx">aquí.</a></h2>
         <p>&nbsp;</p>
         <p>
             <table style="width:100%">
                 <tr>
                     <th>
                        &nbsp;<a href="UsersAdministration.aspx"><img src="images/users.png" style="width:48%; height:193px;"/></a><br />
                     <br />
                     <a href="UsersAdministration.aspx">
                        &nbsp;<br />
                         Administradores
                     </a>
                     </th>
                      <td>
                          <a href="frmReportes.aspx">
                        <img src="images/encuesta.png" style="width:15%;height:15%;"/><br />
                     </a>
                          <br />
                          <a href="frmReportes.aspx">
                         Reportes
                     </a>
                     </td>
                 </tr>
                 

             </table>
         </p>
		 <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <br />
                  
                     <br />
                     <br />
                    
				  </div>
				  <div class="col-md-6 contact-right">
				 </div>
				 <div class="clearfix"></div>
	     </div>
</div>
        </div>
</asp:Content>
