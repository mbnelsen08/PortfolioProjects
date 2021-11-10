$(document).ready(function () {
  loadDvds();
  createNewDvd();
  updateDvd();
  search();
});

function loadDvds() {
  var contentRows = $('#contentRows');
  contentRows.empty();
  $.ajax({
    type: 'GET',
    url: 'https://localhost:44329/dvds',
    success: function(dvdArray){
      $.each(dvdArray, function(index, dvd){
        var title = dvd.title;
        var releaseYear = dvd.releaseYear;
        var director = dvd.director;
        var rating = dvd.rating;
        var notes = dvd.notes;
        var id = dvd.dvdId;
        var row = '<tr>';
            row += '<td><button type="button" class="btn btn-success"><a onclick="showMovieDetails('+id+')">' + title + '</a></button></td>';
            row += '<td>' + releaseYear + '</td>';
            row += '<td>' + director + '</td>';
            row += '<td>' + rating + '</td>';
            row += '<td><button type="button" class="btn btn-info"><a onclick="showEditForm('+id+')">Edit</a></button></td>';
            row += '<td><button type="button" class="btn btn-danger"><a onclick="confirmDelete('+id+')">Delete</a></button></td>';
            row += '</tr>';
        contentRows.append(row);
      })
    },
    error: function() {
      $('#errorMessages')
        .append($('<li>')
        .attr({class: 'list-group-item list-group-item-danger'})
        .text('Error calling web service. Please try again later.'));
    }
  })
}

function showMovieDetails(id) {
  var contentRows = $('#contentRowsDisplay');
  var titleElement = $('#displayTableTitle');
  contentRows.empty();
  $('#displayTableTitle').empty();
  $.ajax({
    type: 'GET',
    url: 'https://localhost:44329/dvd/' + id,
    success: function(data, status){
      var title = data.title;
      var releaseYear = data.releaseYear;
      var director = data.director;
      var rating = data.rating;
      var notes = data.notes;
      var row = '<tr><td>Title: </td><td>' + title + '</td></tr>';
          row += '<tr><td>Release Year: </td><td>' + releaseYear + '</td></tr>';
          row += '<tr><td>Director: </td><td>' + director + '</td></tr>';
          row += '<tr><td>Rating: </td><td>' + rating + '</td></tr>';
          row += '<tr><td>Notes: </td><td>' + notes + '</td></tr>';
      contentRows.append(row);
      titleElement.append(title);
    },
    error: function(){
      $('#errorMessages')
        .append($('<li>')
        .attr({class: 'list-group-item list-group-item-danger'})
        .text('Error calling web service. Please try again later.'));
      }
    })

  $('#dvdDisplayDiv').show();
  $('#dvdTableDiv').hide();
  $('#searchTableDiv').hide();
}

function hideDvdDisplay() {
  $('#dvdDisplayDiv').hide();
  $('#dvdTableDiv').show();
}

function showAddForm() {
  $("#errorMessages").empty();
  $('#dvdTableDiv').hide();
  $('#addFormDiv').show();
}

function hideAddForm() {
  $('#dvdTableDiv').show();
  $('#addFormDiv').hide();
  $('#errorMessages').empty();
}

function hideEditForm() {
  $('#dvdTableDiv').show();
  $('#editFormDiv').hide();
  $('#errorMessages').empty();
}

function createNewDvd() {
  $('#addButton').click(function (event) {

    var haveValidationErrorsTitle = checkAndDisplayValidationErrors($('#addForm').find('#addTitle'));
    var haveValidationErrorsYear = checkAndDisplayValidationErrors($('#addForm').find('#addReleaseYear'));

        if(haveValidationErrorsTitle) {
          $('#errorMessages').empty();
          $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text('Please enter a movie title.'));
            return false;
        }
        if(haveValidationErrorsYear || $('#addReleaseYear').val().length != 4 ||  /\D/.test($('#addReleaseYear').val())) {
          $('#errorMessages').empty();
          $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text('Please enter a 4-digit year.'));
            return false;
        }

    $.ajax({
      type: 'POST',
      url: 'https://localhost:44329/dvd',
      data: JSON.stringify({
        title: $('#addTitle').val(),
        releaseYear: $('#addReleaseYear').val(),
        director: $('#addDirector').val(),
        rating: $('#addRating').val(),
        notes: $('#addNotes').val()
      }),
      headers: {
        'Accept': 'application/json',
        'Content-Type':'application/json'
      },
      'dataType':'json',
      success: function() {
        $('#errorMessages').empty();
        $('#addTitle').val('');
        $('#addReleaseYear').val('');
        $('#addDirector').val('');
        $('#addRating').val('');
        $('#addNotes').val('');
        loadDvds();
        $('#contentRows').empty();
        $('#addFormDiv').hide();
        $('#dvdTableDiv').show();
      },
      error: function() {
        $('#errorMessages')
          .append($('<li>')
          .attr({class: 'list-group-item list-group-item-danger'})
          .text('Error calling web service. Please try again later.'));
      }
    })

  })
}

function confirmDelete(id) {
  var isConfirm = confirm("Press OK to confirm delete.");
  if (isConfirm == true) {
    deleteDvd(id);
  }
}

function deleteDvd(id) {
  $.ajax({
    type: 'DELETE',
    url: 'https://localhost:44329/dvd/' + id,
    success: function() {
      loadDvds();
    }
  })
}

function showEditForm(id) {
  $('#errorMessages').empty();

  $.ajax({
    type: 'GET',
    url: 'https://localhost:44329/dvd/' + id,
    success: function(data, status) {
      $('#editTitle').val(data.title);
      $('#editReleaseYear').val(data.releaseYear);
      $('#editDirector').val(data.director);
      $('#editRating').val(data.rating);
      $('#editNotes').val(data.notes);
      $('#editDvdId').val(data.dvdId);
    },
    error: function(){
      $('#errorMessages')
        .append($('<li>')
        .attr({class: 'list-group-item list-group-item-danger'})
        .text('Error calling web service. Please try again later.'));
    }
  })
  $('#dvdTableDiv').hide();
  $('#searchCategory').val("Search Category");
  $('#searchText').val('');
  $('#searchTableDiv').hide();
  $('#editFormDiv').show();
}

function updateDvd() {
  $('#editButton').click(function(event) {
    var haveValidationErrorsTitle = checkAndDisplayValidationErrors($('#editForm').find('#editTitle'));
    var haveValidationErrorsYear = checkAndDisplayValidationErrors($('#editForm').find('#editReleaseYear'));

        if(haveValidationErrorsTitle) {
          $('#errorMessages').empty();
          $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text('Please enter a movie title.'));
            return false;
        }
        if(haveValidationErrorsYear || $('#editReleaseYear').val().length !=4 || /\D/.test($('#editReleaseYear').val())) {
          $('#errorMessages').empty();
          $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text('Please enter a 4-digit year.'));
            return false;
        }
    $.ajax({
      type: 'PUT',
      url: 'https://localhost:44329/dvd/' + $('#editDvdId').val(),
      data: JSON.stringify({
        title: $('#editTitle').val(),
        releaseYear: $('#editReleaseYear').val(),
        director: $('#editDirector').val(),
        rating: $('#editRating').val(),
        notes: $('#editNotes').val(),
        dvdId: $('#editDvdId').val()
      }),
      headers: {
        'Accept':'application/json',
        'Content-Type':'application/json'
      },
      'datatype': 'json',
      success: function() {
        $('#errorMessages').empty();
        hideEditForm();
        loadDvds();
      },
      error: function() {
        $('#errorMessages')
        .append($('<li>')
        .attr({class: 'list-group-item list-group-item-danger'})
        .text('Error calling web service. Please try again later.'));
      }
    })
  })
}

function hideSearchTable(){
  var searchContentRows = $('#searchContentRows');
  searchContentRows.empty();
  $('#dvdTableDiv').show();
  $('#searchTableDiv').hide();
  $('#searchCategory').val('');
  $('#searchText').val('');
}

function search() {
  $('#searchButton').click(function(event){
    var haveValidationErrors = false;
    if($('#searchText').val()==""){
      haveValidationErrors = true;
    }
    var haveValidationErrorsTwo = checkAndDisplayValidationErrors($('#searchForm').find('select'));

        if( haveValidationErrorsTwo|| haveValidationErrors) {
            $('#errorMessages').empty();
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text('Both Search Category and Search Term are Required.'));
            return false;
        }
    var searchCategory = $('#searchCategory').val();
    var searchText = $('#searchText').val();
    $('#dvdTableDiv').hide();
    $('#searchTableDiv').show();
    $('#searchContentRows').empty();
    showSearchResults(searchCategory, searchText);
  })
}

function showSearchResults(searchCategory, searchText) {
    $('#dvdTableDiv').hide();
    $('#searchTableDiv').show();
    var searchContentRows = $('#searchContentRows');
    if(searchCategory=="1"){
      $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvd/title/'+searchText,
        success: function(dvdArray){
          $.each(dvdArray, function(index, dvd){
            var title = dvd.title;
            var releaseYear = dvd.releaseYear;
            var director = dvd.director;
            var rating = dvd.rating;
            var notes = dvd.notes;
            var id = dvd.id;
            var row = '<tr>';
                row += '<td><button type="button" class="btn btn-success"><a onclick="showMovieDetails('+id+')">' + title + '</a></button></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-info"><a onclick="showEditForm('+id+')">Edit</a></button></td>';
                row += '<td><button type="button" class="btn btn-danger"><a onclick="deleteDvd('+id+')">Delete</a></button></td>';
                row += '</tr>';
            searchContentRows.append(row);
          })
        },
        error: function() {
          $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
      })
    }
    if(searchCategory=="2"){
      $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvd/year/'+searchText,
        success: function(dvdArray){
          $.each(dvdArray, function(index, dvd){
            var title = dvd.title;
            var releaseYear = dvd.releaseYear;
            var director = dvd.director;
            var rating = dvd.rating;
            var notes = dvd.notes;
            var id = dvd.id;
            var row = '<tr>';
                row += '<td><button type="button" class="btn btn-success"><a onclick="showMovieDetails('+id+')">' + title + '</a></button></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-info"><a onclick="showEditForm('+id+')">Edit</a></button></td>';
                row += '<td><button type="button" class="btn btn-danger"><a onclick="deleteDvd('+id+')">Delete</a></button></td>';
                row += '</tr>';
            searchContentRows.append(row);
          })
        },
        error: function() {
          $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
      })
    }
    if(searchCategory=="3"){
      $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvd/director/'+searchText,
        success: function(dvdArray){
          $.each(dvdArray, function(index, dvd){
            var title = dvd.title;
            var releaseYear = dvd.releaseYear;
            var director = dvd.director;
            var rating = dvd.rating;
            var notes = dvd.notes;
            var id = dvd.id;
            var row = '<tr>';
                row += '<td><button type="button" class="btn btn-success"><a onclick="showMovieDetails('+id+')">' + title + '</a></button></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-info"><a onclick="showEditForm('+id+')">Edit</a></button></td>';
                row += '<td><button type="button" class="btn btn-danger"><a onclick="deleteDvd('+id+')">Delete</a></button></td>';
                row += '</tr>';
            searchContentRows.append(row);
          })
        },
        error: function() {
          $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
      })
    }
    if(searchCategory=="4"){
      $.ajax({
        type: 'GET',
        url: 'https://localhost:44329/dvd/rating/'+searchText,
        success: function(dvdArray){
          $.each(dvdArray, function(index, dvd){
            var title = dvd.title;
            var releaseYear = dvd.releaseYear;
            var director = dvd.director;
            var rating = dvd.rating;
            var notes = dvd.notes;
            var id = dvd.id;
            var row = '<tr>';
                row += '<td><button type="button" class="btn btn-success"><a onclick="showMovieDetails('+id+')">' + title + '</a></button></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><button type="button" class="btn btn-info"><a onclick="showEditForm('+id+')">Edit</a></button></td>';
                row += '<td><button type="button" class="btn btn-danger"><a onclick="deleteDvd('+id+')">Delete</a></button></td>';
                row += '</tr>';
            searchContentRows.append(row);
          })
        },
        error: function() {
          $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
      })
    }
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function() {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message) {
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}
