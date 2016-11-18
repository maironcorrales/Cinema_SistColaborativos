<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="frmReporteProyeccion.aspx.cs" Inherits="CinemaColaborativos.frmReporteProyeccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="head">Reporte de proyecciones</h3>
    <br />
    <br />Selecciona una película:<br />
                         &nbsp;<asp:DropDownList ID="ddlPeliculas" runat="server" Height="35px" OnSelectedIndexChanged="ddlPeliculas_SelectedIndexChanged" Width="797px">
        <asp:ListItem>Seleccione una película</asp:ListItem>
    </asp:DropDownList>
    <br />
    <div class="form-group">
                &nbsp;<br />
        <asp:Button ID="btnBuscar" runat="server"   BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar"  PostBackUrl="~/frmReporteProyeccion.aspx" />
                &nbsp; 
        <asp:Button ID="btnLimpiarDatos" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnLimpiar_Click" Text="Limpiar" OnUnload="btnLimpiar_Click" PostBackUrl="~/frmReporteProyeccion.aspx" />
        <br />
        <br />
        <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False"  Visible="False" ForeColor="Black" Height="141px" Width="1288px">
            <Columns>
                   <asp:ImageField DataImageUrlField ="foto">
                     <ControlStyle Height="80%" Width="100%" />
                 </asp:ImageField>
                <asp:BoundField DataField="nombre" HeaderText="Película" />
                <asp:BoundField DataField="resumen" HeaderText="Resumen" />
                <asp:BoundField DataField="duracion" HeaderText="Minutos" />
                <asp:BoundField DataField="genero" HeaderText="Género" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="hora" HeaderText="Hora" />
                <asp:BoundField DataField="id_sala" HeaderText="Número de sala" />
                <asp:BoundField DataField="tipo_sala" HeaderText="Sala" />
            </Columns>
            <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnRegresar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnRegresar_Click"  PostBackUrl="~/frmReporteProyeccion.aspx" Text="Regresar" />
    </div>
       <SCRIPT language=Javascript>
      function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
   </SCRIPT>
</asp:Content>
