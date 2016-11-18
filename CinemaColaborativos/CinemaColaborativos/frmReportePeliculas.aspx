<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="frmReportePeliculas.aspx.cs" Inherits="CinemaColaborativos.frmReportePeliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
     <div class="contact-content">
         <div class="main-contact">
         <h3 class="head">Reporte de películas</h3>
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
                         <br />
                         Rango de Fechas de Projecciones:<br />
                         </span>
                         <div class="form-group">
                             <span class="">Desde:&nbsp;&nbsp;<select class="form-control" runat="server" id="fromDay" tabindex="1" style="width:100%;" name="D1">
                                                <option selected="selected" value="">Día</option>
                                                <option value="01">01</option>
                                                <option value="02">02</option>
                                                <option value="03">03</option>
                                                <option value="04">04</option>
                                                <option value="05">05</option>
                                                <option value="06">06</option>
                                                <option value="07">07</option>
                                                <option value="08">08</option>
                                                <option value="09">09</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                                <option value="12">13</option>
                                                <option value="12">14</option>
                                                <option value="12">15</option>
                                                <option value="12">16</option>
                                                <option value="12">17</option>
                                                <option value="12">18</option>
                                                <option value="12">19</option>
                                                <option value="12">20</option>
                                                <option value="12">21</option>
                                                <option value="12">22</option>
                                                <option value="12">23</option>
                                                <option value="12">24</option>
                                                <option value="12">25</option>
                                                <option value="12">26</option>
                                                <option value="12">27</option>
                                                <option value="12">28</option>
                                                <option value="12">29</option>
                                                <option value="12">30</option>
                                                <option value="12">31</option>
                                            </select><select class="form-control" runat="server" id="fromYear" tabindex="1" style="width:100%;" name="D2">
                                                <option selected="selected" value="">Mes</option>
                                                <option value="01">Enero</option>
                                                <option value="02">Febrero</option>
                                                <option value="03">Marzo</option>
                                                <option value="04">Abril</option>
                                                <option value="05">Mayo</option>
                                                <option value="06">Junio</option>
                                                <option value="07">Julio</option>
                                                <option value="08">Agosto</option>
                                                <option value="09">Setiembre</option>
                                                <option value="10">Octubre</option>
                                                <option value="11">Noviembre</option>
                                                <option value="12">Diciembre</option>
                                            </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>&nbsp;<span class=""><br />
                             Hasta:</span><br />
                                            <select class="form-control" runat="server" id="ToDay" tabindex="1" style="width:100%;" name="D3">
                                                <option selected="selected" value="">Día</option>
                                                <option value="01">01</option>
                                                <option value="02">02</option>
                                                <option value="03">03</option>
                                                <option value="04">04</option>
                                                <option value="05">05</option>
                                                <option value="06">06</option>
                                                <option value="07">07</option>
                                                <option value="08">08</option>
                                                <option value="09">09</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                                <option value="12">13</option>
                                                <option value="12">14</option>
                                                <option value="12">15</option>
                                                <option value="12">16</option>
                                                <option value="12">17</option>
                                                <option value="12">18</option>
                                                <option value="12">19</option>
                                                <option value="12">20</option>
                                                <option value="12">21</option>
                                                <option value="12">22</option>
                                                <option value="12">23</option>
                                                <option value="12">24</option>
                                                <option value="12">25</option>
                                                <option value="12">26</option>
                                                <option value="12">27</option>
                                                <option value="12">28</option>
                                                <option value="12">29</option>
                                                <option value="12">30</option>
                                                <option value="12">31</option>
                                            </select><select class="form-control" runat="server" id="toYear" tabindex="1" style="width:100%;" name="D4">
                                                <option selected="selected" value="">Mes</option>
                                                <option value="01">Enero</option>
                                                <option value="02">Febrero</option>
                                                <option value="03">Marzo</option>
                                                <option value="04">Abril</option>
                                                <option value="05">Mayo</option>
                                                <option value="06">Junio</option>
                                                <option value="07">Julio</option>
                                                <option value="08">Agosto</option>
                                                <option value="09">Setiembre</option>
                                                <option value="10">Octubre</option>
                                                <option value="11">Noviembre</option>
                                                <option value="12">Diciembre</option>
                                                
                                            </select><br />
                             <br />
                             <br />
&nbsp;<asp:Button ID="btnBuscar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar" OnUnload="btnBuscar_Click" PostBackUrl="~/frmReportePeliculas.aspx" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnLimpiarDatos" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnLimpiar_Click" Text="Limpiar" OnUnload="btnLimpiar_Click" PostBackUrl="~/frmReportePeliculas.aspx" />
                                <br />
                             <br />
                             <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="resultado_SelectedIndexChanged" Visible="False" ForeColor="Black"  Height="141px" Width="1288px">
                                 <Columns>
                                     <asp:ImageField DataImageUrlField ="foto">
                                         <ControlStyle Height="80%" Width="100%" />
                                     </asp:ImageField>
                                     <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                     <asp:BoundField DataField="resumen" HeaderText="Resumen" />
                                     <asp:BoundField DataField="duracion" HeaderText="Duración" />
                                     <asp:BoundField DataField="genero" HeaderText="Género" />
                                     <asp:BoundField DataField="rango_fechas" HeaderText="Rango de fechas" />
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
