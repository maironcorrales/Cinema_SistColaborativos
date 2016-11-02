<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="Projection.aspx.cs" Inherits="CinemaColaborativos.Projection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="reviews-section">
				<h3 class="head" runat="server" id="movieName"></h3>
					<div class="col-md-9 reviews-grids">
                        <div class="review">
							<div class="movie-pic">
								<img runat="server" id="movieImg" alt="" />
							</div>
							<div class="review-info">
								<a class="span">Resumen <i>de la pelicula</i></a>
								<p class="dirctr" runat="server" id="description"></p>								
								<p class="ratingview">Critic's Rating:</p>
								<div class="rating">
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
								</div>
								<p class="ratingview">
								&nbsp;3.5/5  
								</p>
								<div class="clearfix"></div>
								<p class="ratingview c-rating">Avg Readers' Rating:</p>
								<div class="rating c-rating">
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
									<span>☆</span>
								</div> 	
								<p class="ratingview c-rating">								
								&nbsp; 3.3/5</p>
								<div class="clearfix"></div>
								<p class="info" runat="server" id="gender" ></p>
								<p class="info" runat="server" id="duration" ></p>
								<p class="info" runat="server" id="dates"></p>
							</div>
							<div class="clearfix"></div>
						</div>
                        <div class="story-review">
                            <h3>Escoja la función de su preferencia</h3>
                        </div>
                        <asp:Repeater runat="server" ID="ProjectionRepeater" OnItemDataBound="ProjectionRepeater_ItemDataBound" OnItemCommand="ProjectionRepeater_ItemCommand">
                            <ItemTemplate>
                                <div class="story-review">
                                    <h3 runat="server" id="projectionNumber">Funcion</h3>
                                
                                <div class="single">
							        <p runat="server" id="projectionDate"></p>
                                    <p runat="server" id="projectionStartTime"></p>
                                    <asp:HiddenField runat="server" ID="projectionID" />
                                    <asp:HiddenField runat="server" ID="projectionState" />
                                    <h4 runat="server" id="theaterID"></h4>
								    <p runat="server" id="theaterType"></p>
                                    <asp:LinkButton CssClass="button play-icon popup-with-zoom-anim" runat="server" ID="buyTicket" CommandName="BuyTicket" Text="Comprar Tiquetes" Style="position:center;width:25%;text-align:center" ></asp:LinkButton>
						            <asp:Button ID="processbtn" runat="server" Style="visibility:hidden"/>
                                </div>
                                    </div>
                                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                  
                                            TargetControlID="processbtn"
                                            PopupControlID="Panel1"
                                            Drag="true"
                                            BackgroundCssClass="modalBackground">
                                     </asp:ModalPopupExtender>
                                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
                                            CancelControlID="btnCancel"
                                            TargetControlID="processbtn"
                                            PopupControlID="Panel2"
                                            Drag="true"
                                            BackgroundCssClass="modalBackground">
                                     </asp:ModalPopupExtender>
                                </ItemTemplate>
                        </asp:Repeater>
                        <asp:Panel ID="Panel1" Style="display: none" CssClass="modalPopup" align="center" runat="server">
                            <p runat="server" id="message">Escoja el número de entradas que desea.</p>
                                <div class="clearfix"> </div>
                            <hr />
                            <div class="quantity"">
                                  <input runat="server" id="ticketQuantity" type="number" min="1" max="10" step="1" value="1"/>
                                </div>
                                <input class="button play-icon popup-with-zoom-anim" runat="server" id="AcepptTicketBtn" onserverclick="AcepptTicketBtn_ServerClick" style="width:50%;height:35%" type="button" value="Aceptar" />
                            </asp:Panel>
                        <asp:Panel ID="Panel2" Style="display: none" CssClass="modalPopup" align="center" runat="server">
                            <p runat="server" id="sorryMessage"></p><a runat="server" id="link"></a>
                                <div class="clearfix"> </div>
                                <input class="button play-icon popup-with-zoom-anim" id="btnCancel" type="button" value="Aceptar" />
                            </asp:Panel>
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
                height: 140px;
            }
        </style>
    <style>
        .quantity {
  position: center;
}

input[type=number]::-webkit-inner-spin-button,
input[type=number]::-webkit-outer-spin-button
{
  -webkit-appearance: none;
  margin: 0;
}

input[type=number]
{
  -moz-appearance: textfield;
}

.quantity input {
  width: 70px;
  height: 42px;
  line-height: 1.65;
  float: left;
  display: block;
  padding: 0;
  margin: 0;
  padding-left: 20px;
  border: 1px solid #eee;
}

.quantity input:focus {
  outline: 0;
}

.quantity-nav {
  float: left;
  position: relative;
  height: 42px;
  
}

.quantity-button {
  position: relative;
  cursor: pointer;
  border-left: 1px solid #eee;
  width: 20px;
  text-align: center;
  color: #333;
  font-size: 13px;
  font-family: "Trebuchet MS", Helvetica, sans-serif !important;
  line-height: 1.7;
  -webkit-transform: translateX(-100%);
  transform: translateX(-100%);
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  -o-user-select: none;
  user-select: none;
}

.quantity-button.quantity-up {
  position: absolute;
  height: 50%;
  top: 0;
  border-bottom: 1px solid #eee;
}

.quantity-button.quantity-down {
  position: absolute;
  bottom: -1px;
  height: 50%;
}
    </style>
    <script>
    jQuery('<div class="quantity-nav"><div class="quantity-button quantity-up">+</div><div class="quantity-button quantity-down">-</div></div>').insertAfter('.quantity input');
    jQuery('.quantity').each(function() {
      var spinner = jQuery(this),
        input = spinner.find('input[type="number"]'),
        btnUp = spinner.find('.quantity-up'),
        btnDown = spinner.find('.quantity-down'),
        min = input.attr('min'),
        max = input.attr('max');

      btnUp.click(function() {
        var oldValue = parseFloat(input.val());
        if (oldValue >= max) {
          var newVal = oldValue;
        } else {
          var newVal = oldValue + 1;
        }
        spinner.find("input").val(newVal);
        spinner.find("input").trigger("change");
      });

      btnDown.click(function() {
        var oldValue = parseFloat(input.val());
        if (oldValue <= min) {
          var newVal = oldValue;
        } else {
          var newVal = oldValue - 1;
        }
        spinner.find("input").val(newVal);
        spinner.find("input").trigger("change");
      });

    });
        </script>
</asp:Content>
