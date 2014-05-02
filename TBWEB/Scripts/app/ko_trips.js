/// <reference path="knockout-2.2.1.js" />
/// <reference path="jquery-2.0.2.js" />
var viewModel = function () {

    self = this;

    self.query = ko.observable('');

    self.Trips = ko.observableArray();

    self.currentPage = ko.observable();
    self.pageSize = ko.observable(10);
    self.currentPageIndex = ko.observable(0);

    self.currentTripBids = ko.observable();

    //search
    self.search = function () {

        if (self.query && self.query.toString().length > 3) {
            $("#divProcessing").show();
            $.ajax({
                url: baseUrl + "/api/Trips" //+ self.query
                , type: "GET",
                data: { query: self.query },
                error: function (request, error) {
                    console.log("Error: " + request.requestText + request.status + error);
                    $("#myCarousel").show();
                    $("#divProcessing").hide();
                    $("#left-sidebar").hide();
                }
            }).done(function (data) {
                self.Trips(data);
                $("#myCarousel").slideUp("slow", function () {
                    // Animation complete.
                });
                $("#divProcessing").hide();
                $("#left-sidebar").show();

            });
        };
    };
    //extra info



//    this.TripsCount = ko.observable();
    self.TripsCount = ko.computed(function () {
        // Knockout tracks dependencies automatically. It knows that fullName depends on firstName      and lastName, because these get called when evaluating fullName.
        return this.Trips().length;
    }, this);


    moment.lang('es');

    self.TripIdString = ko.computed(function (trip) {
        // Knockout tracks dependencies automatically. It knows that fullName depends on firstName      and lastName, because these get called when evaluating fullName.
        return this.TripId;
    }, this);

    //details
    
    this.expanded = ko.observable(true);

    this.linkLabel = ko.computed(function () {
        return this.expanded ? "collapse" : "expand";
    }, this);

    self.toggle = function () {
        this.expanded = !this.expanded;
    };

    
    //showbids
    self.ShowBids = function (currentTrip, event) {

        currentTrip.showingdetails = ko.observable();

        $("#divProcessing").show();

        $.ajax({
            url: baseUrl + "/api/CustomerBids" //+ self.query
            , type: "GET",
            data: { TripId: currentTrip.id },
            error: function (request, error) {
                console.log("Error: " + request.requestText + request.status + error);
                $("#divProcessing").hide();
            }
        }).done(function (data) {
            //currentTrip.Bids = ko.observable();
            //currentTrip.Bids(data);
            self.currentTripBids(data);

            $("#divProcessing").hide();
//            $(event.target).closest('#details').show();

        });
    };

    

    //Sorting and paging

    self.sortType = "ascending";

   // self.Trips = self.Trips.groupBy("Trip");

    self.currentColumn = ko.observable("");
    self.iconType = ko.observable("");

    self.currentPage = ko.computed(function () {
        var pagesize = parseInt(self.pageSize(), 10),
        startIndex = pagesize * self.currentPageIndex(),
        endIndex = startIndex + pagesize;
        return self.Trips.slice(startIndex, endIndex);
    });

    self.nextPage = function () {
        if (((self.currentPageIndex() + 1) * self.pageSize()) < self.Trips().length) {
            self.currentPageIndex(self.currentPageIndex() + 1);
        }
        else {
            self.currentPageIndex(0);
        }
    };

    self.previousPage = function () {
        if (self.currentPageIndex() > 0) {
            self.currentPageIndex(self.currentPageIndex() - 1);
        }
        else {
            self.currentPageIndex((Math.ceil(self.Trips().length / self.pageSize())) - 1);
        }
    };

    self.sortTable = function (viewModel, e) {
        var orderProp = $(e.target).attr("data-column")
        self.currentColumn(orderProp);
        self.Trips.sort(function (left, right) {
            leftVal = left[orderProp];
            rightVal = right[orderProp];
            if (self.sortType == "ascending") {
                return leftVal < rightVal ? 1 : -1;
            }
            else {
                return leftVal > rightVal ? 1 : -1;
            }
        });
        self.sortType = (self.sortType == "ascending") ? "descending" : "ascending";
        self.iconType((self.sortType == "ascending") ? "icon-chevron-up" : "icon-chevron-down");
    };
}

$(document).ready(function () {


    var vm = new viewModel();

    //$.ajax({
    //    url: baseUrl + "/api/Trips",
    //    type: "GET",
    //    error: function (request, error) {
    //        alert("R: " + request.requestText +  request.status + error);
    //    }
    //}).done(function (data) {
    //    vm.Trips(data);
    //});




    //    var url = "../trips/Data"; //$(this).attr("action");
    //    var formData = $(this).serialize();

    ////    //    data: formData,
    //    $.ajax({
    //       url: url,
    //        type: "POST",
    //        dataType: "json",
    //        error: function (request, error) {
    //            alert("R: " + request.requestText);
    //            alert("R: " + request.status);
    //            alert("ERROR: " + error);
    //        },
    //        success: function (resp) {
    //            // Hide the "busy" gif:
    //            $("#divProcessing").hide();
    //            $("#myCarousel").hide();

    //            vm.trip(resp);

    //        }
    //    })

    ko.applyBindings(vm);

    vm.query.subscribe(vm.search);

    

});