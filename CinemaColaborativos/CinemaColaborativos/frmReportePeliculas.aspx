<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="frmReportePeliculas.aspx.cs" Inherits="CinemaColaborativos.frmReportePeliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
     <div class="contact-content">
         <div class="main-contact">
         <h3 class="head">Consulta de películas registradas</h3>
             <p class="head">
                             <asp:Button ID="btnRegresar0" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnRegresar_Click"  PostBackUrl="~/frmReportePeliculas.aspx" Text="Regresar" />
                             </p>
             <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <div class="form-group">
                         Nombre:
                         &nbsp;<asp:TextBox ID="txtNombre" runat="server" Height="100%" Width="100%"></asp:TextBox>
                         <br />
                         <br />
                         Género<br />
                         <asp:DropDownList ID="DrpListGenero" runat="server" Height="100%" Width="100%">
                             <asp:ListItem Selected="True">Género</asp:ListItem>
                             <asp:ListItem>Acción</asp:ListItem>
                             <asp:ListItem>Horror</asp:ListItem>
                             <asp:ListItem>Aventura</asp:ListItem>
                             <asp:ListItem>Animación</asp:ListItem>
                             <asp:ListItem>Suspenso</asp:ListItem>
                             <asp:ListItem>Fantasía</asp:ListItem>
                             <asp:ListItem>Comedia</asp:ListItem>
                         </asp:DropDownList>
                         <br />
                         <span id="lblExpiryDate" class="">
                         <br />
                         </span>
                         <div class="form-group">
&nbsp;<asp:Button ID="btnBuscar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar" OnUnload="btnBuscar_Click" PostBackUrl="~/frmReportePeliculas.aspx" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnLimpiarDatos" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnLimpiar_Click" Text="Limpiar" OnUnload="btnLimpiar_Click" PostBackUrl="~/frmReportePeliculas.aspx" />
                                <br />
                             <br />
                             <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="resultado_SelectedIndexChanged" Visible="False" ForeColor="Black"  Height="100%" Width="100%">
                                 <Columns>
                                     <asp:ImageField DataImageUrlField ="foto">
                                         <ControlStyle Height="80%" Width="100%" />
                                     </asp:ImageField>
                                     <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                     <asp:BoundField DataField="resumen" HeaderText="Resumen" />
                                     <asp:BoundField DataField="duracion" HeaderText="Duración" />
                                     <asp:BoundField DataField="genero" HeaderText="Género" />
                                     <asp:BoundField DataField="rango_fechas" HeaderText="Rango de fechas" Visible="False" />
                                 </Columns>
                                 <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" />
                             </asp:GridView>
                             <br />
                             <asp:Button ID="btnRegresar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnRegresar_Click"  PostBackUrl="~/frmReportePeliculas.aspx" Text="Regresar" />
                             <br />
                                </div>
                     </div>
                     
				  </div>
                 <asp:Panel ID="Panel2" Style="display:none" CssClass="modalPopup" align="center" runat="server">
                                        <p runat="server" id="resultMessage"></p>
                                        <hr />
                                        <a id="btnAccept"  class="button play-icon popup-with-zoom-anim" style="width:30%; text-align:center; height:30%;"  runat="server">Aceptar</a>
                                    </asp:Panel>
	     </div>
         </div>
     </div>
</asp:Content>
