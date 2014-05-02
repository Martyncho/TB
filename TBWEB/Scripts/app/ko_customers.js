/// <reference path="knockout-2.2.1.js" />
/// <reference path="jquery-2.0.2.js" />
var viewModel = function () {

    $this = this;

    $this.query = ko.observable('');

    $this.customer = ko.observableArray();

    $this.currentPage = ko.observable();
    $this.pageSize = ko.observable(10);
    $this.currentPageIndex = ko.observable(0);

    $this.Bids = ko.observableArray();
//    $this.Trips = ko.observableArray();
//    $this.Trips = $this.Bids.

    $this.search = function() {
//        alert($this.query);

        $.ajax({
            url: "../api/CustomerBids" //+ $this.query
            ,type: "GET",
            data: { query: $this.query },
            error: function (request, error) {
                alert("R: " + request.requestText);
                alert("R: " + request.status);
                alert("ERROR: " + error);
            }
        }).done(function (data) {
            $this.Bids(data);
        });
    };

    //extra info

//    this.BidsCount = ko.observable();
    this.BidsCount = ko.computed(function () {
        // Knockout tracks dependencies automatically. It knows that fullName depends on firstName      and lastName, because these get called when evaluating fullName.
        return this.Bids().length;
    }, this);



    //Sorting and paging

    $this.sortType = "ascending";

   // $this.Trips = $this.Bids.groupBy("Trip");

    $this.currentColumn = ko.observable("");
    $this.iconType = ko.observable("");

    $this.currentPage = ko.computed(function () {
        var pagesize = parseInt($this.pageSize(), 10),
        startIndex = pagesize * $this.currentPageIndex(),
        endIndex = startIndex + pagesize;
        return $this.Bids.slice(startIndex, endIndex);
    });

    $this.nextPage = function () {
        if ((($this.currentPageIndex() + 1) * $this.pageSize()) < $this.Bids().length) {
            $this.currentPageIndex($this.currentPageIndex() + 1);
        }
        else {
            $this.currentPageIndex(0);
        }
    };

    $this.previousPage = function () {
        if ($this.currentPageIndex() > 0) {
            $this.currentPageIndex($this.currentPageIndex() - 1);
        }
        else {
            $this.currentPageIndex((Math.ceil($this.Bids().length / $this.pageSize())) - 1);
        }
    };

    $this.sortTable = function (viewModel, e) {
        var orderProp = $(e.target).attr("data-column")
        $this.currentColumn(orderProp);
        $this.Bids.sort(function (left, right) {
            leftVal = left[orderProp];
            rightVal = right[orderProp];
            if ($this.sortType == "ascending") {
                return leftVal < rightVal ? 1 : -1;
            }
            else {
                return leftVal > rightVal ? 1 : -1;
            }
        });
        $this.sortType = ($this.sortType == "ascending") ? "descending" : "ascending";
        $this.iconType(($this.sortType == "ascending") ? "icon-chevron-up" : "icon-chevron-down");
    };
}

$(document).ready(function () {


    var vm = new viewModel();

    $.ajax({
        url: "../api/CustomerBids",
        type: "GET",
        error: function (request, error) {
            alert("R: " + request.requestText);
            alert("R: " + request.status);

            alert("ERROR: " + error);
        }
    }).done(function (data) {
        vm.Bids(data);
    });

    //    var url = "../Customers/Data"; //$(this).attr("action");
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

    //            vm.customer(resp);

    //        }
    //    })

    ko.applyBindings(vm);

    vm.query.subscribe(vm.search);


});