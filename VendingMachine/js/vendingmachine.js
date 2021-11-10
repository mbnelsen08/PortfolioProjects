$(document).ready(function () {
  loadItems();
  addFunds();
  makeChange();
  makePurchase();
});

function loadItems() {
  var itemDiv = $('#itemDiv');
  itemDiv.empty();
  $.ajax({
    type: 'GET',
    url: 'http://vending.us-east-1.elasticbeanstalk.com/items',
    success: function(itemArray){
      $.each(itemArray, function(index, item){
        var id = item.id;
        var name = item.name;
        var price = parseFloat(item.price).toFixed(2);
        var quantity = item.quantity;
        var box = '<div id="item'+id+'" onclick="itemSelector('+id+')"class="col-md-3 text-center m-2"><p style="text-align:left;">'+item.id+'</p><p>'+item.name+'</p><br/><p>$'+price+'</p><br/><p>Quantity Left: '+item.quantity+'</p></div>';

        itemDiv.append(box);
      })
    },
    error: function() {
      $('#messagesTextArea').val('Error calling web service. Please try again later.')
      $("#messagesTextArea").css("border", " solid red");

    }
  })
}

function addFunds() {
  var funds = 0;
  $('#moneyTextArea').val(funds.toFixed(2));

  $('#addDollarButton').click(function (event) {
    funds+=1;
    $('#moneyTextArea').val(funds.toFixed(2));
    clearMessagesChange();
  })

  $('#addQuarterButton').click(function (event) {
    funds+=.25;
    $('#moneyTextArea').val(funds.toFixed(2));
    clearMessagesChange();
  })

  $('#addDimeButton').click(function (event) {
    funds+=.10;
    $('#moneyTextArea').val(funds.toFixed(2));
    clearMessagesChange();
  })

  $('#addNickelButton').click(function (event) {
    funds+=.05;
    $('#moneyTextArea').val(funds.toFixed(2));
    clearMessagesChange();
  })
}

function itemSelector(itemId) {
  var newItemId = '#item'+itemId;
  $('#itemDisplayTextArea').val(itemId);
  $('#changeTextArea').val('');
  $('#messagesTextArea').val('');
  $("#messagesTextArea").css("border", "solid black");
  $('#itemDiv').children().css("border", "solid black");
  $('#itemDiv').children().css("color", "black");
  $(newItemId).css("border", "solid blue");
  $(newItemId).css("color", "blue");
}

function makeChange() {
  var funds = 0;
  $('#changeReturnButton').click(function (event) {
    funds = $('#moneyTextArea').val();

    var dollars = 0;
    var quarters = 0;
    var dimes = 0;
    var nickels = 0;
    var pennies = 0;

    while((funds-1)>=0){
      dollars+=1;
      funds = (funds-1).toFixed(2);
    }
    while((funds-0.25)>=0){
      quarters+=1;
      funds = (funds-0.25).toFixed(2);
    }
    while((funds-0.10)>=0){
      dimes+=1;
      funds = (funds-0.1).toFixed(2);
    }
    while((funds-0.05)>=0.00){
      nickels+=1;
      funds = funds-0.05;
    }
    while((funds-0.01)>=0.00){
      pennies+=1;
      funds = (funds-0.01).toFixed(2);
    }


    $('#moneyTextArea').val(0);
    $('#messagesTextArea').val('');
    $('#itemDisplayTextArea').val('');
    $("#messagesTextArea").css("border", " solid black");
    createChangeMessage(dollars,quarters,dimes,nickels,pennies);
  })
}

function createChangeMessage(dollars,quarters,dimes,nickels,pennies) {
  addFunds();
  loadItems();

  var changeText = '';

  if(dollars==1){
    changeText+=dollars+' Dollar ';
  }
  if(dollars>1){
    changeText+=dollars+' Dollars ';
  }

  if(quarters==1){
    changeText+=quarters+' Quarter ';
  }
  if(quarters>1){
    changeText+=quarters+' Quarters ';
  }

  if(dimes==1){
    changeText+=dimes+' Dime ';
  }
  if(dimes>1){
    changeText+=dimes+' Dimes ';
  }

  if(nickels==1){
    changeText+=nickels+' Nickel ';
  }
  if(nickels>1){
    changeText+=nickels+' Nickels ';
  }

  if(pennies==1){
    changeText+=pennies+' Penny ';
  }
  if(pennies>1){
    changeText+=pennies+' Pennies ';
  }

  $('#changeTextArea').val(changeText);
}

function makePurchase() {
  $('#makePurchaseButton').click(function (event) {
    var amount = $('#moneyTextArea').val();
    var itemId = $('#itemDisplayTextArea').val();
    if(amount == ''){
      $('#messagesTextArea').val("Please insert funds to make a purchase.");
      $("#messagesTextArea").css("border", " solid red");
      return false;
    }
    if(itemId == ''){
      $('#messagesTextArea').val("Please select an item to purchase.");
      $("#messagesTextArea").css("border", " solid red");
      return false;
    }

    $.ajax({
      type: 'POST',
      url: 'http://vending.us-east-1.elasticbeanstalk.com/money/'+amount+'/item/'+itemId,
      headers: {
        'Accept': 'application/json',
        'Content-Type':'application/json'
      },
      'dataType':'json',
      success: function(data, status) {
        var dollars = 0;
        var quarters = data.quarters.toFixed();
        var dimes = data.dimes.toFixed();
        var nickels = data.nickels.toFixed();
        var pennies = data.pennies.toFixed();

        createChangeMessage(dollars,quarters,dimes,nickels,pennies);
        $('#messagesTextArea').val('Thank for purchasing item # '+ itemId);
        $("#messagesTextArea").css("border", " solid green");
        $('#itemDisplayTextArea').val('');
        $('#moneyTextArea').val('');
      },
      error: function(data, status, error) {
        var response = JSON.parse(data.responseText);
        $('#messagesTextArea').val(response.message);
        $("#messagesTextArea").css("border", " solid red");
      }
    })
  })
}

function clearMessagesChange() {
  $('#changeTextArea').val('');
  $('#messagesTextArea').val('');
  $("#messagesTextArea").css("border", "solid black");
}
