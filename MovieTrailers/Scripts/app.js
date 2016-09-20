$('#searchBtn').on('click', function () {
    var keyword = $("#search").val();
    //$.ajax({
    //    type: "GET",
    //    //data: JSON.stringify(keyword),
    //    url: "api/Search/?keyword=" + keyword
    //});
    $.getJSON("api/Search/?keyword=" + keyword, function (data) {
        var items = [];
        var videos = [];
        $.each(data, function (key, val) {
            items.push("<a href='#' class='list-group-item' onclick='callModal(\"" + val.id + "\")' id='" + val.id + "'>" +
                "<h5 class='list-group-item-heading'>" + val.title + " </h5>" +
                "<p class'list-group-item-text'>" + val.titleDescription + "</p><br/>" +
                "<img src='" + val.thumbnail + "'/>" +
                "</a>");
            videos.push("<div id='modal" + val.id + "' class='modal'>" +
                    "<div class='modal-content'><div class='modal-header'>" +
                    "<a class='close' onclick='closeModal(\"" + val.id + "\")' >X</a>" +
                    "<h2>" + val.title + "</h2></div>" +
                    "<div class='modal-body'>" +
                    "<iframe id='iframe" + val.id + "' width='520' height='315' src=''></iframe></div>" +
                    "</div></div>");
        });

        $(".list-group").empty();
        $(".videos").empty();

        $("<div>", {
            "class": "list-group my-new-list",
            html: items.join("")
        }).appendTo(".jumbotron");

        $("<div>", {
            "class": "videos",
            html: videos.join("")
        }).appendTo(".jumbotron");
    });
});

// When the user clicks the button, open the modal
function callModal(id) {
    // Get the modal
    var modal = document.getElementById("modal" + id);
    document.getElementById('iframe' + id).src = "https://www.youtube.com/embed/" + id;
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
function closeModal(id) {
    document.getElementById('iframe' + id).src = "";
    var modal = document.getElementById("modal" + id);
    modal.style.display = "none";
}