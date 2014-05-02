

function getCountries() {
    $("#CityId").html();
    $("#StateId").html();

    $.ajax({
        url: baseUrl + "/api/Locations/GetCountries",
    dataType: "json",
    type: "GET",
    error: function () {
        alert("An error occurred.");
    },
    success: function (data) {
        var items = "";
        $.each(data, function (i, item) {
            
            if ((typeof currentcountryid != "undefined" && currentcountryid != null && currentcountryid == item.CountryId) || ((typeof currentcountryid == "undefined" || currentcountryid == null) && item.IsDefault == true)) {
                items += "<option  selected=\"true\"  value=\"" + item.CountryId + "\">" + item.Name + "</option>";
            } else {
                items += "<option  value=\"" + item.CountryId + "\">" + item.Name + "</option>";
            }
        });

        $("#CountryId").html(items);

        var Id = $("#CountryId").val();
        getStates(Id);


    }
});
}


function getCities(StateId) {
    $("#CityId").html();
    $("#CityId").val();

    $.ajax({
        url: baseUrl + "/api/Locations/GetCities",
    data: { StateId: StateId },
    dataType: "json",
    type: "GET",
    error: function () {
        alert("An error occurred.");
    },
    success: function (data) {
        var items = "";
        $.each(data, function (i, item) {
            if ((typeof currentcityid != "undefined" && currentcityid != null && currentcityid == item.CityId) || ((typeof currentcityid == "undefined" || currentcityid == null) && item.IsDefault == true)) {
                items += "<option  selected=\"true\"  value=\"" + item.CityId + "\">" + item.Name + "</option>";
            }
            else {
                items += "<option    value=\"" + item.CityId + "\">" + item.Name + "</option>";
            }
        });

        $("#CityId").html(items);
    }
});
}

function getStates(CountryId) {
    $("#CityId").html();
    $("#StateId").html();
    $("#CityId").val();
    $("#StateId").val();

    $.ajax({
        url: baseUrl + "/api/Locations/GetStates",
    data: { CountryId: CountryId },
    dataType: "json",
    type: "GET",
    error: function () {
        alert("An error occurred.");
    },
    success: function (data) {
        var items = "";
        $.each(data, function (i, item) {
            if ((typeof currentstateid != "undefined" && currentstateid != null && currentstateid == item.StateId) || ((typeof currentstateid == "undefined" || currentstateid == null) && item.IsDefault == true)) {
                items += "<option  selected=\"true\"  value=\"" + item.StateId + "\">" + item.Name + "</option>";
            }
            else {
                items += "<option value=\"" + item.StateId + "\">" + item.Name + "</option>";
            }
        });

        $("#StateId").html(items);

        var Id = $("#StateId").val();
        getCities(Id);

    }
});
}


$(document).ready(function () {


    getCountries();

    $("#CountryId").change(function () {
        var Id = $("#CountryId").val();
        getStates(Id);
    });

    $("#StateId").change(function () {
        var Id = $("#StateId").val();
        getCities(Id);
    });

    //$("#CountryId").change(function () {
    //    var Id = $("#CountryId").val();
    //    getStates(Id);
    //});
});
