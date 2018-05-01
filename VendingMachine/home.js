$(document).ready(function () {

    loadItems();

});

function loadItems() {
    var itemsList = $('#itemsListDiv')

    $.ajax({

        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(itemArray) {
            $.each(itemArray, function(index, item){
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                itemsList.append("<div class='col-md-4'> <div class='container itemDisplay' id='itemDisplay#" + id + "' onclick='selectItem(" + id + ", " + price + ", " + quantity + ")'> <div class='row'> <div class='col-md-12'> <div id='itemId' style='text-align: left'> " + id + " </div> </div> </div> <div class='row'> <div class='col-md-12'> <div id='itemName'> " + name + " </div> </div> </div> <div class='row'> <div class='col-md-12'> <div id='itemPrice'> " + price + " </div> </div> </div> <br/> <br/> <div class='row'> <div class='col-md-12'> <div id='itemQuantityId" + id + "'> " + quantity + " </div> </div> </div> </div> </div>")
            });
        },
        error: function() {
            $('#error-messages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later.'));
        }

    });

}

function makePurchase() {

    $('#machine-messages-display').empty();
    $('#return-change-button').hide();
    $('#error-messages').empty();
    
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + $('#total-cash-display').val() + '/item/' + $('#item-id-display').val(),
        success: function(response) {
            $.each(response, function(index, message){
                var quarters = message.quarters;
                var dimes = message.dimes;
                var nickels = message.nickels;
                var pennies = message.pennies;

                if (Number(quarters) > 0){
                    var returnQuarters = quarters + ' Quarter';
                }
                else if (Number(quarters) > 1){
                    var returnQuarters = quarters + ' Quarters';
                }
                else {
                    var returnQuarters = '';
                }

                if (Number(dimes) > 0){
                    var returnDimes = dimes + ' Dime';
                }
                else if (Number(dimes) > 1){
                    var returnDimes = dimes + ' Dimes';
                }
                else {
                    var returnDimes = '';
                }

                if (Number(nickels) > 0){
                    var returnNickels = nickels + ' Nickel';
                }
                else if (Number(nickels) > 1){
                    var returnNickels = nickels + ' Nickels';
                }
                else {
                    var returnNickels = '';
                }

                if (Number(pennies) > 0){
                    var returnPennies = pennies + ' Penny';
                }
                else if (Number(pennies) > 1){
                    var returnPennies = pennies + ' Pennies';
                }
                else {
                    var returnPennies = '';
                }

                $('#display-change').val(returnQuarters + returnDimes + returnNickels + returnPennies);
                $('#machine-messages-display').val('Thank You!!!');

                loadItems();
            });
        },
        error: function(response) {
            
            var machineMessage = response.message;
            
            $('#machine-messages-display').val(machineMessage);
        }
    })

}

function selectItem(id, price, quantity) {

    $('#error-messages').empty();
    
    $('#item-id-display').val(id);
    $('#item-price-holder').val(price);
    $('#item-quantity-holder').val(quantity);

}



function notEnoughCash(totalCash, itemPrice) {

    $('#machine-messages-display').empty();

    cash = Number(totalCash);
    price = Number(itemPrice);
    difference = (price - cash).toFixed(2);

    $('#machine-messages-display').val('Please Deposit: $' + difference);

}

function completePurchase(totalCash, itemPrice) {
    
    var id = $('#item-id-display').val();
    var path = "#itemQuantityId" + id;
    $('#machine-messages-display').empty();
    var newQuantity = Number($('#item-quantity-holder').val()) - 1;
    $(path).val('');

    cash = Number(totalCash);
    price = Number(itemPrice);
    change = (cash - price).toFixed(2);

    $('#machine-messages-display').val('Thank You!!!');
    if (change > 0.04) {
        $('#display-change').val('$' + change)
    }
}

function itemSoldOut() {

    $('#machine-messages-display').empty();

    $('#machine-messages-display').val('SOLD OUT!!!');

}

function returnChange() {

    $('#display-change').val($('#total-cash-display').val());
    $('#total-cash-display').val('');

    cancelTransaction();

}

function cancelTransaction() {

    $('#machine-messages-display').val('');
    $('#item-id-display').val('');
}

function addDollar() {

    $('#return-change-button').show();


    var money = 1.00;
    var oldBalance = Number($('#total-cash-display').val());
    var midBalance = (oldBalance + money);
    var newBalance = midBalance.toFixed(2);

    displayCash(newBalance);

}

function addQuarter() {

    $('#return-change-button').show();


    var money = 0.25;
    var oldBalance = Number($('#total-cash-display').val());
    var midBalance = (oldBalance + money);
    var newBalance = midBalance.toFixed(2);

    displayCash(newBalance);

}

function addDime() {

    $('#return-change-button').show();


    var money = 0.10;
    var oldBalance = Number($('#total-cash-display').val());
    var midBalance = (oldBalance + money);
    var newBalance = midBalance.toFixed(2);

    displayCash(newBalance);

}

function addNickel() {

    $('#return-change-button').show();


    var money = 0.05;
    var oldBalance = Number($('#total-cash-display').val());
    var midBalance = (oldBalance + money);
    var newBalance = midBalance.toFixed(2);

    displayCash(newBalance);

}

function displayCash(balance) {

    $('#total-cash-display').val(balance);

}
