<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="frmConsultaHistoriaPeliculas.aspx.cs" Inherits="CinemaColaborativos.frmConsultaHistoriaPeliculas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 contact-left">
        <div class="form-group">
            <h3 class="head">Consulta histórica de películas</h3>
            <br />
            <br />
            <div class="form-group">
                &nbsp;<br />
                <asp:Button ID="btnBuscar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar" OnUnload="btnBuscar_Click" PostBackUrl="~/frmConsultaHistoriaPeliculas.aspx" />
                <br />
                <br />
                <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False"  Visible="False" ForeColor="Black" Height="141px" Width="1288px" OnRowDataBound="cargarDatos" >
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Película" />
                        <asp:BoundField DataField="genero" HeaderText="Género" />
                        <asp:BoundField DataField="id_factura" HeaderText="Número de factura" />
                        <asp:BoundField DataField="id_reservacion" HeaderText="Cantidad de sillas" />
                        <asp:BoundField DataField="tipo_sala" HeaderText="Sala" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                        <asp:TemplateField HeaderText = "Valoración" >
                            <ItemTemplate>
                                    <asp:DropDownList ID="ddlValoraciones" runat="server"  AutoPostBack="True"  onselectedindexchanged="itemSelected" >
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                    </asp:DropDownList>
                            </ItemTemplate>
        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" />
                </asp:GridView>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
