<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="frmReporteSalas.aspx.cs" Inherits="CinemaColaborativos.frmReporteSalas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact-form">
        <div class="col-md-6 contact-left">
            <div class="form-group">
         <h3 class="head">Reporte de salas</h3>
                <br />
                <br />
                Cantidad de sillas:
                         &nbsp;<asp:TextBox ID="txtCantidadSillas" onkeypress="return isNumberKey(event)" runat="server" Height="100%" Width="100%"></asp:TextBox>
                <br />
                <br />Tipo de sala<br />
                <asp:DropDownList ID="DrpListTipo" runat="server" Height="100%" Width="100%">
                    <asp:ListItem>IMAX</asp:ListItem>
                    <asp:ListItem>2D</asp:ListItem>
                    <asp:ListItem>3D</asp:ListItem>
                    <asp:ListItem>4DX</asp:ListItem>
                </asp:DropDownList>
                <br /><span id="lblExpiryDate" class="">
                <br />
                <br />Estado:<br />
                <asp:CheckBox ID="chkEstado" runat="server" Checked="True" Text="Activa" />
                <br /></span>
                <div class="form-group">
                    <br />
                    <br />
                    <br />&nbsp;<asp:Button ID="btnBuscar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnBuscar_Click" Text="Buscar" OnUnload="btnBuscar_Click" PostBackUrl="~/frmReporteSalas.aspx" />
                    &nbsp; <asp:Button ID="btnLimpiarDatos" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnLimpiar_Click" Text="Limpiar" OnUnload="btnLimpiar_Click" PostBackUrl="~/frmReporteSalas.aspx" />
                    <br />
                    <br />
                    <asp:GridView ID="resultado" runat="server" AutoGenerateColumns="False"  Visible="False" ForeColor="Black" Height="141px" Width="1288px">
                        <Columns>
                            <asp:BoundField DataField="id_sala" HeaderText="Número de sala" />
                            <asp:BoundField DataField="tipo_sala" HeaderText="Tipo de sala" />
                            <asp:BoundField DataField="numero_asientos" HeaderText="Cantidad de sillas" />
                            <asp:CheckBoxField DataField="estado" HeaderText="Estado" ReadOnly="True" />
                        </Columns>
                        <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" />
                    </asp:GridView>
                    <br />
                             <asp:Button ID="btnRegresar" runat="server" BackColor="Black" CssClass="btn" ForeColor="White" OnClick="btnRegresar_Click"  PostBackUrl="~/frmReporteSalas.aspx" Text="Regresar" />
                    <br />
                </div>
            </div>
        </div>
        <asp:Panel ID="Panel2" Style="display:none" CssClass="modalPopup" align="center" runat="server">
            <p runat="server" id="resultMessage">
            </p>
            <hr />
            <a id="btnAccept"  class="button play-icon popup-with-zoom-anim" style="width:30%; text-align:center; height:30%;"  runat="server">Aceptar</a>
        </asp:Panel>
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
