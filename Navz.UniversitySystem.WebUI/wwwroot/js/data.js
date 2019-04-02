"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();

connection.on("UpdateData", function (name) {
    if ($("#Data").attr("data-name") == name) {
        GetData();
    }
});

connection.start().then(function () {
    if ($("#Data").length) {
        GetData();
    }
}).catch(function (err) {
    return console.error(err.toString());
});

function GetData() {
    var tag = $("#Data");
    $.get(tag.attr("data-url"), function (response, status) {
        tag.html("");

        //turn response from server into table
        var mydata = eval(response);
        var table = $.makeTable(mydata[tag.attr("data-collection")]);
        $(table).appendTo(tag);

        $("#create").toggle(mydata["createEnabled"]);
    });
}

$.makeTable = function (mydata) {
    var table = $('<table class="table">');
    var tblHeader = "<tr>";
    for (var k in mydata[0]) tblHeader += "<th>" + k.toUpperCase() + "</th>";
    tblHeader += "<th></th>";
    tblHeader += "</tr>";
    $(tblHeader).appendTo(table);
    $.each(mydata, function (index, value) {
        var TableRow = "<tr>";
        $.each(value, function (key, val) {
            TableRow += "<td>" + val + "</td>";
        });
        TableRow += "<td><a href='" + $("#Data").attr("data-name") +"/Detail/" + value["id"] + "'>Detail</a></td>"
        TableRow += "</tr>";
        $(table).append(TableRow);
    });
    return ($(table));
};