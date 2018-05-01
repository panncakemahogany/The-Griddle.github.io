$(document).ready(function () {

    

});

function loadAllDvds() {
    clearDvdTable();
    var dvdList = $('#contentRows');

    $.ajax({

        type: 'GET',
        url: 'http://localhost:56924/dvds',
        success: function(dvdArray) {
            $.each(dvdArray, function(index, dvd){

                var dvdId = dvd.dvdId
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes;

                var row = '<tr>';
                    row += '<td>' + name + '</td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td> <a onclick="editDvd(' + dvdId + ')">Edit</a> | <a onclick="deleteDvd(' + dvdId + ')">Delete</a> </td>';
                    row += '</tr>';

                dvdList.append(row);

            });
        },
        error: function() {
            $('#error-messages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later.'));
        }

    })
}

function clearDvdTable() {

    $('#contentRows').empty();

}

function editDvd(dvdId) {

}

function dvdSearch() {

}

function createDvd() {

}

function deleteDvd(dvdId) {

}