<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="frmReporteFactura.aspx.cs" Inherits="CinemaColaborativos.frmReporteFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 contact-left">
        <div class="form-group">
            <h3 class="head">Impresión de factura</h3>
            <br />
            <br />Ingrese el número de factura:
                         &nbsp;<asp:TextBox ID="txtNumeroFactura" runat="server" Height="100%" Width="100%"></asp:TextBox>
            <br />
            <div class="form-group">
                &nbsp;<br />
                <asp:Button ID="btnBuscar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar" OnUnload="btnBuscar_Click" PostBackUrl="~/frmReporteFactura.aspx" />
                <br />
                <br />
                <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False"  Visible="False" ForeColor="Black" Height="141px" Width="1288px">
                    <Columns>
                        <asp:BoundField DataField="genero" HeaderText="Género" />
                        <asp:BoundField DataField="nombre" HeaderText="Película" />
                        <asp:BoundField DataField="id_reservacion" HeaderText="Número de reserva" />
                        <asp:BoundField DataField="estado_reservacion" HeaderText="Estado" Visible="False" />
                        <asp:BoundField DataField="id_factura" HeaderText="Número de factura" />
                        <asp:BoundField DataField="monto" HeaderText="Monto" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="tipo_sala" HeaderText="Sala" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="id_sala" HeaderText="Número de sala" />
                        <asp:BoundField DataField="correo" HeaderText="Correo electrónico" />
                    </Columns>
                    <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" />
                </asp:GridView>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
