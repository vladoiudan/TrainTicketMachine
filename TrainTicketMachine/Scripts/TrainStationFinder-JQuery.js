function filterStations(e) {
    var url = "api/Stations?filter=";
    $.ajax({
        url: url + e + '"',
        dataType: 'json'
    }).success(function (data) {
        $('.btn').each(function () {
            var btn = $(this);
            var found = false;
            $.each(data.NextPossibleCharacters, function (i, obj) {
                if (obj == btn.text()) {
                    found = true;
                    return;
                }
            });
            if (found) {
                btn.removeAttr('disabled');
            } else {
                btn.attr('disabled', 'disabled');
            }
            $('#searchResults > tbody').empty();
            $.each(data.Stations, function (i, obj) {
                $('#searchResults').append('<tr><td>' + obj + '</td></tr>');
            });
        });
    }).error(function (err) {
        alert(err);
    });
}

function changeStationNameFilterText(newfilter) {
    $('#stationName').val(newfilter);
    $("#stationName").trigger("change");
    if ($('#stationName').val().length > 0) {
        $('.backspaceBtn').removeAttr('disabled');
    } else {
        $('.backspaceBtn').attr('disabled', 'disabled');
    }
}

(function ($) {
    $("#stationName").on("change paste keyup", function (e) {
        filterStations(this.value);
    });

    $('.btn').click(function () {
        changeStationNameFilterText($('#stationName').val() + this.textContent);
    });
    $('.backspaceBtn').click(function () {
        var currentText = $('#stationName').val();
        changeStationNameFilterText(currentText.substring(0, currentText.length - 1));

    });
    changeStationNameFilterText("");
})(jQuery);
