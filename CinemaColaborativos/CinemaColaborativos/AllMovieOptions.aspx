<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="AllMovieOptions.aspx.cs" Inherits="CinemaColaborativos.AllMovieOptions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="error-content">
                <div class="error-404 text-center">
				<p>Todas las películas</p>
                    <asp:Repeater runat ="server" ID="TodaysMovieRepeater" OnItemDataBound="TodaysMovieRepeater_ItemDataBound" OnItemCommand="TodaysMovieRepeater_ItemCommand">
                            <ItemTemplate>
                                <div class="content-grid" runat="server" id="movieDiv">
                                    <asp:HiddenField runat="server" ID="movieID" />
                                    <img runat="server" id="movieImage" />
                                    <h3 runat="server" id="name"></h3>
                                    <asp:LinkButton CssClass="button play-icon popup-with-zoom-anim" runat="server" ID="Edit" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                    <asp:LinkButton CssClass="button play-icon popup-with-zoom-anim" runat="server" ID="Delete" CommandName="Delete" Text="ELiminar"></asp:LinkButton>
                                    <asp:LinkButton CssClass="button play-icon popup-with-zoom-anim" runat="server" ID="Projections" CommandName="Projections" Text="Projecciones"></asp:LinkButton>
                                    <asp:Button ID="processbtn" runat="server" Style="visibility:hidden"/>
                                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                            CancelControlID="btnCancel"
                                            TargetControlID="processbtn"
                                            PopupControlID="Panel1"
                                            Drag="true"
                                            BackgroundCssClass="modalBackground">
                                     </asp:ModalPopupExtender>
                                </div>
                             </ItemTemplate>
                        </asp:Repeater>
                </div>
         </div>
</asp:Content>
