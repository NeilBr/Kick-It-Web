function selectChal(data) {
    $("#ulBLChallenges").html($("#ulBLChallenges").html() + '<li class="dashPopupli liReport"><div class= "dashliInfo" >' +
        data.item.value + '</div >  </li >');
    console.log("yaaaas");
}

function loadDivs() {
    var reportsURL = '/Home/Reports';
    $.ajax({
        url: reportsURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            console.log(data);
            var obj = JSON.parse(data);
            console.log(obj);

            var newHTML = "<ul class=\"dashUl\">";
           
            $.each(obj, function (index, r) {
                    newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + r.adv_id +
                        "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                        " <img class=\"btnDashLiImg btnImgX\" />" +
                        " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgAdd \" />" +
                        "</button></div></li>";
                });
            newHTML += " </ul>";
            console.log(newHTML);
            $("#reportWindow").html( newHTML);
        },
        error: function () { alert("Something went wrong with getting the reported posts..") },
    });

    var challengeURL = '/Home/Challenges';
    $.ajax({
        url: challengeURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            console.log(data);
            var obj = JSON.parse(data);
            console.log(obj);

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, c) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + c.c_description +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgX\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgAdd \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
            console.log(newHTML);
            $("#challengeWindow").html(newHTML);
        },
        error: function () { alert("Something went wrong with getting the reported posts..") },
    });

    var usersURL = '/Home/Users';
    $.ajax({
        url: reportsURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            console.log(data);
            var obj = JSON.parse(data);
            console.log(obj);

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, c) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + c.c_description +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgX\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgAdd \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
            console.log(newHTML);
            $("#challengeWindow").html(newHTML);
        },
        error: function () { alert("Something went wrong with getting the reported posts..") },
    });

    $.ajax({
        url: "https://fiddle.jshell.net/favicon.png",
        async: true
    })
        .done(function (data) {
            console.log("4th");
        });

    $.ajax({
        url: "https://fiddle.jshell.net/favicon.png",
        async: true
    })
        .done(function (data) {
            console.log("5th");
        });

}

