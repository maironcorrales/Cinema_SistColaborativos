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
    <script>
        var price = 5; //price

        function re() {


            var i = 0;
            var c =parseInt('<%=ticketNumber%>');
            var $cart = $('#selected-seats'), //Sitting Area
            $counter = $('#counter'), //Votes
            $total = $('#total'); //Total money

            var sc = $('#seat-map').seatCharts({
                map: [  //Seating chart
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa',
                    'aaaaaaaaaa'
                ],
                naming: {
                    top: false,
                    getLabel: function (character, row, column) {
                        return column;
                    }
                },
                legend: { //Definition legend
                    node: $('#legend'),
                    items: [
                        ['a', 'available', 'Espacio'],
                        ['a', 'unavailable', 'Asiento']
                    ]
                },
                click: function () { //Click event
                    if (this.status() == 'available') { //optional seat

                        if (i < c) {

                            $('<li>' + 'F' + (this.settings.row + 1) + ' C' + this.settings.label + '</li>')
                                .attr('id', 'cart-item-' + this.settings.id)

                                .attr('class', this.settings.id)
                                .data('seatId', this.settings.id)
                                .appendTo($cart);

                            $counter.text(sc.find('selected').length + 1);
                            $counter.attr('class', (sc.find('selected').length + 1));
                            $total.text(recalculateTotal(sc) + price);
                            i++;



                            return 'selected';
                        } else {
                            return 'available';
                        }
                    } else if (this.status() == 'selected') { //Checked
                        //Update Number
                        $counter.text(sc.find('selected').length - 1);
                        $counter.attr('class', (sc.find('selected').length - 1));
                        i--;
                        //update totalnum
                        $total.text(recalculateTotal(sc) - price);

                        //Delete reservation
                        $('#cart-item-' + this.settings.id).remove();
                        //optional
                        return 'available';
                    } else if (this.status() == 'unavailable') { //sold
                        return 'unavailable';
                    } else {
                        return this.style();
                    }
                }

            });
            //sold seat
            var h = '';
            z = document.getElementById("vector1").value;
            console.log(z + "este es z")
            h = z.split(",")
            console.log(h);
            sc.get(h).status('unavailable');

        }
        //sum total money
        function recalculateTotal(sc) {
            var total = 0;
            sc.find('selected').each(function () {
                total += price;
            });

            return total;
        }
    </script>
</asp:Content>

