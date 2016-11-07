<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="SeatReservation.aspx.cs" Inherits="CinemaColaborativos.SeatReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script src="js/jquery.responsivetable.min.js"></script>
    <script src="js/jquery-painSeats.js"></script>
    <script src="js/jquery.seat-charts.min.js"></script>
    <script src="js/Seat.js"></script>
    <script src="js/SeatDesign.js"></script>
    <script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
    <link href="css/Seat.css" rel="stylesheet" />

    <div class="contact-content">
        <div class="main-contact">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="contact-form">
                    <asp:HiddenField ID="seat_reservation" runat="server" />
                        <div class="col-mod-8">
                            <div class="special-service">
		                        <h2><span>Seleccione los asientos</span></h2>
	                            <div class="service-tab">
                                    <div id="" class="col-md-6 col-md-offset-3">
                                        <div id="myTabContent" class="tab-content">
	                                        <div class="demo">
   		                                        <div id="seat-map">
			                                        <div class="front">Pantalla</div>					
		                                        </div>
		                                        <div class="booking-details">
                                                    <p>Pelicula: <span> Mr. Nobody</span></p>
				                                    <p>Asientos: </p>
				                                    <ul id="selected-seats"></ul>
				                                    <p>Cantidad de Asientos: <span id="counter">0</span></p>
                                                    <p>Total: <b>$<span id="total">0</span></b></p>
                                                    <button class="rm-btn btn btn-primary" onclick="save()">Reservar</button>
			                                        <input id="vector1" type="hidden" name="vector1" >
			                                        <div id="legend"></div>
		                                        </div>
		                                        <div style="clear:both"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="contact_info"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
 
    <script>
        $(window).on('load', function () {
		    re();    
		    $(".demo").scroll();
		});
		$('#myTab a').click(function (e) {
		    e.preventDefault()
            $(this).tab('show')
		    })
    </script>	
</asp:Content>

