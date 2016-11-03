<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CinemaColaborativos.Home" EnableEventValidation="false" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">	
			<div class="header-info">
				<h1>BIG HERO 6</h1>
				<p class="age"><a href="#">All Age</a> Don Hall, Chris Williams</p>
				<p class="review">Rating	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp;&nbsp;  8,5/10</p>
				<p class="review reviewgo">Genre	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : &nbsp;&nbsp; Animation, Action, Comedy</p>
				<p class="review">Release &nbsp;&nbsp;&nbsp;&nbsp;: &nbsp;&nbsp; 7 November 2014</p>
				<p class="special">The special bond that develops between plus-sized inflatable robot Baymax, and prodigy Hiro Hamada, who team up with a group of friends to form a band of high-tech heroes.</p>
				<a class="video" href="#"><i class="video1"></i>WATCH TRAILER</a>
				<a class="book" href="#"><i class="book1"></i>BOOK TICKET</a>
			</div>
		</div>
    <div class="review-slider">
			 <ul id="flexiselDemo1">
			<li><img src="images/r1.jpg" alt=""/></li>
			<li><img src="images/r2.jpg" alt=""/></li>
			<li><img src="images/r3.jpg" alt=""/></li>
			<li><img src="images/r4.jpg" alt=""/></li>
			<li><img src="images/r5.jpg" alt=""/></li>
			<li><img src="images/r6.jpg" alt=""/></li>
		</ul>
			<script type="text/javascript">
		$(window).load(function() {
			
		  $("#flexiselDemo1").flexisel({
				visibleItems: 6,
				animationSpeed: 1000,
				autoPlay: true,
				autoPlaySpeed: 3000,    		
				pauseOnHover: false,
				enableResponsiveBreakpoints: true,
				responsiveBreakpoints: { 
					portrait: { 
						changePoint:480,
						visibleItems: 2
					}, 
					landscape: { 
						changePoint:640,
						visibleItems: 3
					},
					tablet: { 
						changePoint:768,
						visibleItems: 4
					}
				}
			});
			});
		</script>
		<script type="text/javascript" src="js/jquery.flexisel.js"></script>	
		</div>
    <div class="right-content">
				<div class="right-content-heading">
					<div class="right-content-heading-left">
						<h3 class="head">Cartelera</h3>
					</div>
				</div>
               
				<div class="content-grids">
                     <asp:Repeater runat ="server" ID="TodaysMovieRepeater" OnItemDataBound="TodaysMovieRepeater_ItemDataBound" OnItemCommand="TodaysMovieRepeater_ItemCommand">
                            <ItemTemplate>
                                <div class="content-grid" runat="server" id="movieDiv">
                                    <asp:HiddenField runat="server" ID="movieID" />
                                    <img runat="server" id="movieImage" />
                                    <h3 runat="server" id="name"></h3>
                                    <asp:LinkButton CssClass="button play-icon popup-with-zoom-anim" runat="server" ID="buyTicket" CommandName="Book" Text="Comprar Tiquetes"></asp:LinkButton>
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
                    	 <asp:Panel ID="Panel1" Style="display: none" CssClass="modalPopup" align="center" runat="server">
                            <p runat="server" id="message"></p><a runat="server" id="link"></a>
                                <div class="clearfix"> </div>
                                <input class="button play-icon popup-with-zoom-anim" id="btnCancel" type="button" value="Aceptar" />
                            </asp:Panel>
                    	
					<div class="clearfix"> </div>
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
                height: 160px;
            }
        </style>
</asp:Content>
