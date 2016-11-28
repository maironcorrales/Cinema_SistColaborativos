<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="ProjectionOptions.aspx.cs" Inherits="CinemaColaborativos.ProjectionOptions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/tableStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-content">
       
                <div class="error-404 text-center">
				<p runat="server" id="projectionTittle"></p>
                     <table cellspacing="0">
                        <tr>
                            <th style="width:10%">Id</th>
                            <th style="width:20%">Fecha</th>
                            <th style="width:20%">Hora</th>
                            <th style="width:20%">Sala</th>
                            <th style="width:20%">Cambiar Estado</th>
                            <th style="width:20%">Acción</th>
                        </tr>
                         
                             <asp:Repeater ID="ProjectionRepeater" runat="server" OnItemDataBound="ProjectionRepeater_ItemDataBound" OnItemCommand="ProjectionRepeater_ItemCommand">
                                 <ItemTemplate>
                                     <tr>
                                      <td><asp:Label runat="server" ID="ProID"/></td>
                                        <td><asp:Label runat="server" ID="ProDate"/></td>
                                        <td><asp:Label runat="server" ID="ProTime"/></td>
                                        <td><asp:Label runat="server" ID="ProTheater"/></td>
                                        <td><asp:LinkButton runat="server" CommandName="ChangeStatus" ID="changeStatus"></asp:LinkButton></td>
                                        <td><asp:LinkButton runat="server" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                            <asp:LinkButton runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                        </td>
                                       </tr>
                                 </ItemTemplate>
                             </asp:Repeater>
                      </table>
                </div>
        </div>
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
                height: 180px;
            }
        </style>
</asp:Content>
