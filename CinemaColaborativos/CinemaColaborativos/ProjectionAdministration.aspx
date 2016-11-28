<%@ Page Title="" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="ProjectionAdministration.aspx.cs" Inherits="CinemaColaborativos.ProjectionAdministration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contact-content">
         <div class="main-contact">
            <h3 class="head">Administración de Proyecciones</h3>
             <div class="contact-form">
				 <div class="col-md-6 contact-left">
                     <div>
                        <h2 runat="server" id="movieProjection"></h2><br />
                     </div>
                     <div class="form-group">
                         <p>Fecha de proyección: <asp:TextBox ID="eventDate_txt" runat="server" CssClass="form-control" style="width:80%;" placeholder="Fecha" Width="50%"></asp:TextBox>
                             <asp:ImageButton Height="25px" Width="25px" runat="server" ImageUrl="images/calendar-lt.png" OnClick="imgDate_Click" />
                             <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False">
                                 <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                 <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                 <OtherMonthDayStyle ForeColor="#999999" />
                                 <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                 <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                 <TodayDayStyle BackColor="#CCCCCC" />
                             </asp:Calendar>  </p><br />
                         <p>Hora de la proyección: 
                         <select class="form-control" id="timepicker" runat="server" tabindex="1" style="width:80%;">
                            <option selected="selected" value="">Hora</option>
                            <option value="3:00">3:00</option>
                            <option value="4:00">4:00</option>
                            <option value="5:00">5:00</option>
                            <option value="6:00">6:00</option>
                            <option value="7:00">7:00</option>
                            <option value="8:00">8:00</option>
                            <option value="9:00">9:00</option>
                            <option value="10:00">10:00</option>
                             <option value="11:00">11:00</option>
                             <option value="12:00">12:00</option>
                         </select></p><br />
                         <p>Sala donde será la proyección:
                             <asp:DropDownList ID="theaterSelection" CssClass="form-control" runat="server" style="width:80%;" OnSelectedIndexChanged="theaterSelection_SelectedIndexChanged">
                             </asp:DropDownList>
                         </p><br />
                         <a  runat="server" class="button play-icon popup-with-zoom-anim" id="SaveProjection" onserverclick="Save_ServerClick" style="width:20%;text-align:center;" >Crear</a>
                         <asp:Button ID="processbtn" runat="server" Style="visibility:hidden"/>
                         <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                              
                              TargetControlID="processbtn"
                              PopupControlID="Panel1"
                              Drag="true"
                              BackgroundCssClass="modalBackground">
                         </asp:ModalPopupExtender>
                         <asp:Panel ID="Panel1" Style="display: none" CssClass="modalPopup" align="center" runat="server">
                            <p runat="server" id="message"></p>
                                <div class="clearfix"> </div>
                                <input runat="server" onserverclick="btnCancel_ServerClick" class="button play-icon popup-with-zoom-anim" id="btnCancel" type="button" value="Aceptar" />
                            </asp:Panel>
                     </div>
                     
                 </div>    
         </div>
             <div class="clearfix"></div>
             <a href="ProjectionOptions.aspx" class="button play-icon popup-with-zoom-anim" style="width:20%;text-align:center;"> Proyecciones </a>
     </div> 
                 
    </div>
    <br />
    
    
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
                height: 160px;
            }
        </style>
</asp:Content>
