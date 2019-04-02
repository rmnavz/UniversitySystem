"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/alertHub").build();

connection.on("ReceiveAlert", function (title, message) {
    $("main").prepend(
        '<div class="alert alert-info alert-dismissible"><button type="button" class="close" data-dismiss="alert" >×</button ><strong>' + title + '</strong> ' + message + '</div >'
    )
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});