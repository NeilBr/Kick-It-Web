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
            console.log("Reports");
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
            console.log("Challenges");
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
        error: function () { alert("Something went wrong with getting the suggested challenges...") },
    });

    var usersURL = '/Home/Users';
    $.ajax({
        url: usersURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            console.log("User");
            var obj = JSON.parse(data);
            console.log(obj);

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, a) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\"><img class=\"btnDashLiImg btnImgProfile\" />" + a.adv_firstname + " " + a.adv_surname +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgDelete\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgEdit \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
            console.log(newHTML);
            $("#userWindow").html(newHTML);
        },
        error: function () { alert("Something went wrong with getting the users..") },
    });

    var challengeURL = '/Home/getChallenges';
    $.ajax({
        url: challengeURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            console.log("Challenges");
            var obj = JSON.parse(data);
            console.log(obj);

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, c) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + c.c_description +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgDelete\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgEdit \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
            console.log(newHTML);
            $("#manChallengeWindow").html(newHTML);
        },
        error: function () { alert("Something went wrong with getting the suggested challenges...") },
    });

    var bucketlistURL = '/Home/getBucketlists';
    $.ajax({
        url: bucketlistURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            console.log("Bucketlists");
            var obj = JSON.parse(data);
            console.log(obj);

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, bl) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + bl.bl_description +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgDelete\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgEdit \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
            console.log(newHTML);
            $("#blWindow").html(newHTML);
        },
        error: function () { alert("Something went wrong with getting the suggested challenges...") },
    });

}

