var price = 5; //price

function re() {
    

    var i = 0;
    var c = parseInt(document.getElementById('hi_counter.ClientID').value);
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