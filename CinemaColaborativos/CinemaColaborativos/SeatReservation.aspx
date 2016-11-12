<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="SeatReservation.aspx.cs" Inherits="CinemaColaborativos.SeatReservation" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
  

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   


    <script src="js/jquery.responsivetable.min.js"></script>
    <script src="js/jquery-painSeats.js"></script>
    <script src="js/jquery.seat-charts.min.js"></script>
    
    <script src="js/SeatDesign.js"></script>
    <script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
    <link href="css/Seat.css" rel="stylesheet" />
    <script src="js/Seat.js"></script>

    <div class="contact-content">
        <div class="main-contact">
           
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="width:100%; height:100%;">
            <ContentTemplate>
            <asp:hiddenfield ID="hi_counter" runat="server"/>

                <div class="contact-form">
                        <div class="col-mod-8">

                            <div class="special-service">
		                         <h3 class="head">Reservación</h3>
	                            <div class="service-tab">
                                    <div id="" class="col-md-2 contact-left">
                                    </div>
                                    <div id="" class="col-md-2 contact-right">
                                        <div id="myTabContent" class="tab-content">
	                                        <div class="demo">
   		                                        <div id="seat-map">
                                                    <div>
                                                        <h2>Selecione sus asientos</h2><br />
                                                    </div>
			                                        <div class="front">Pantalla</div>					
		                                        </div>
		                                        <div class="booking-details">
                                                    <div class="form-group">
                                                        <p>Pelicula: <span> Mr. Nobody</span></p>
				                                        <p>Asientos: </p>
				                                        <ul id="selected-seats"></ul>
				                                        <p>Cantidad de Asientos: <span id="counter">0</span></p>
                                                        <p>Total: <b>$<span id="total">0</span></b></p>
                                                     </div>
                                                    <div class="form-group">
                                                         <input class="button play-icon popup-with-zoom-anim" runat="server" id="AcepptReservationBtn" onserverclick="AcepptReservationBtn_ServerClick"  style="width:50%;height:35%" type="button" value="Aceptar" />
                                                        
			                                            <input id="vector1" type="hidden" name="vector1" >
                                                    </div>
			                                        <div id="legend"></div>
		                                        </div>
		                                        <div style="clear:both"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="contact_info">
                                        
                                      
                                 
                                    </div>
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

