<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="frmReorganizacionTickets.aspx.cs" Inherits="CinemaColaborativos.frmReorganizacionTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="head">Reorganización de tickets</h3>
    <br />
    <br />
    <div class="form-group">
                &nbsp;<br />
                <asp:Button ID="btnBuscar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar" OnUnload="btnBuscar_Click" PostBackUrl="~/frmReorganizacionTickets.aspx" />
        <br />
        <br />
        <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False"  Visible="False" ForeColor="Black" Height="100%" Width="100%"  >
            <Columns>
                <asp:ImageField DataImageUrlField ="foto">
                </asp:ImageField>
                <asp:BoundField DataField="nombre" HeaderText="Película" />
                <asp:BoundField DataField="genero" HeaderText="Género" />
                <asp:BoundField DataField="id_factura" HeaderText="Número de factura" />
                <asp:BoundField DataField="tipo_sala" HeaderText="Sala" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                <asp:TemplateField HeaderText = "Sala" >
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlValoraciones" runat="server"  AutoPostBack="True" >
                            
                            <asp:ListItem>10 diciembre 2016 18:00</asp:ListItem>
                            <asp:ListItem>10 diciembre 2016 22:00</asp:ListItem>
                            <asp:ListItem>11 diciembre 2016 13:00</asp:ListItem>
                            <asp:ListItem>11 diciembre 2016 18:00</asp:ListItem>
                            <asp:ListItem>11 diciembre 2016 22:00</asp:ListItem>
                            <asp:ListItem>12 diciembre 2016 18:00</asp:ListItem>
                            <asp:ListItem>22 diciembre 2016 18:00</asp:ListItem>
                            <asp:ListItem>1 enero 2017 22:00</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" />
        </asp:GridView>
    </div>
</asp:Content>
