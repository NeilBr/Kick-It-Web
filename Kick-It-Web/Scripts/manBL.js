function selectChal(data) {
    $("#ulBLChallenges").html($("#ulBLChallenges").html() + '<li class="dashPopupli liReport"><div class= "dashliInfo" >' +
        data.item.label + '</div >  </li >');
}

function loadDivs() {
    var reportsURL = '/Home/Reports';
    $.ajax({
        url: reportsURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
         
            var obj = JSON.parse(data);
          

            var newHTML = "<ul class=\"dashUl\">";
           
            $.each(obj, function (index, r) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\" onclick='openReviewReport("+ r.r_id+")'>" + r.rep_reason +
                        "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                        " <img class=\"btnDashLiImg btnImgX\" />" +
                        " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgAdd \" />" +
                        "</button></div></li>";
                });
            newHTML += " </ul>";
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
           
            var obj = JSON.parse(data);
            

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, c) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + c.c_name +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgX\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgAdd \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
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
            
            var obj = JSON.parse(data);
          

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, a) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\"><img class=\"btnDashLiImg btnImgProfile\" />" + a.adv_firstname + " " + a.adv_surname +
                    "</div> <div class=\"dashliActions\"><button onclick='deleteUser("+ a.adv_id +")' class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgDelete\" />" +
                    " </button><button class=\"btnDash\" onclick='openEditUser(" + a.adv_id + ")'><img class=\"btnDashLiImg btnImgEdit \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
          
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
           
            var obj = JSON.parse(data);
           
            var newHTML = "<ul class=\"dashUl\">";
            var newChallengeHTML = "";
            $.each(obj, function (index, c) {
                newChallengeHTML += ' <option value="' + c.c_id + '">' + c.c_name +'</option>'
                   

                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + c.c_name +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgDelete\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgEdit \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
           
            $("#manChallengeWindow").html(newHTML);
            $("#ManBLselect").html(newChallengeHTML);
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
            
            var obj = JSON.parse(data);
         

            var newHTML = "<ul class=\"dashUl\">";

            $.each(obj, function (index, bl) {
                newHTML += "<li class=\"dashli liReport\"><div class=\"dashliInfo\">" + bl.bl_name +
                    "</div> <div class=\"dashliActions\"><button class=\"btnDash\">" +
                    " <img class=\"btnDashLiImg btnImgDelete\" />" +
                    " </button><button class=\"btnDash\"><img class=\"btnDashLiImg btnImgEdit \" />" +
                    "</button></div></li>";
            });
            newHTML += " </ul>";
         
            $("#blWindow").html(newHTML);
        },
        error: function () { alert("Something went wrong with getting the suggested challenges...") },
    });

}
function saveUser() {
    $.ajax({
        type: 'POST',
        async: true,
        url: '/Home/saveUser',
        data: JSON.stringify({ adventurer: myData }),
        contentType: 'application/json',
        success: function (data) {
            alert("User Created!");
        },
        error: function (err) {
            alert("error creating user- " + err);
        }
    });

}

function deleteUser(userId) {

    if (window.confirm("Are you sure you want to delete this user?")) {
        var deleteUserURL = 'Home/deleteUser/' + userId;
        $.ajax({
            url: deleteUserURL,
            async: true,
            dataType: "text",
            method: 'post',
            success: function (data) {
                if (data = "done") {
                    var replace = "  <img src='https://media.giphy.com/media/QvH4uLw6QfrtE5BxXr/giphy.gif' style=' width:20%; height:20%; left: 40%; position:inherit; margin:auto; top:40%;' />";
                    $("#userWindow").html(replace);
                    $("#reportWindow").html(replace);
                    $("#blWindow").html(replace);
                    $("#manChallengeWindow").html(replace);
                    $("#challengeWindow").html(replace);
                    loadDivs();
                }
            }, error: function () { alert("Something went wrong with Deleting the User...") },
        });

    }
}
function openEditUser(userId) {
    var replace = "  <img src='https://media.giphy.com/media/QvH4uLw6QfrtE5BxXr/giphy.gif' style=' width:20%; height:20%; left: 40%; position:inherit; margin:auto; top:40%;' />";
    $("#userPopupWindow").html(replace);
    $("#userPopupHeading").html("EDIT USER");
    $("#editUser").dialog('open');

    var getUserURL = 'Home/getUser/' + userId;
    $.ajax({
        url: getUserURL,
        async: true,
        dataType: "json",
        method: 'post',
        success: function (data) {
            var userDetails =
                '<input id="advFName" class="popupEdtText" type="text" placeholder="FIRST NAME" value="' + data.adv_firstname + '"/>'
                + ' <input id="advSName" class="popupEdtText" type="text" placeholder="SURNAME" value="' + data.adv_surname + '"/>'
                + ' <input id="advEmail" class="popupEdtText" type="email" placeholder="Email" value="' + data.adv_email + '"/>'
                + ' <input id="advContact" class="popupEdtText" type="text" placeholder="CONTACT" value="' + data.adv_telephone + '"/>'

                + ' <label class="popUpLabel">Admin</label> <br /> <label class="switch">'
                + '<input id="advAdmin" type = "checkbox" ';
            if (data.adv_admin) {
                userDetails += 'checked';
            }
            userDetails += '/> <span class="slider round"></span></label ><br />'
                + '<label class="popUpLabel">Enabled</label> <br />  <label class="switch">'
                + ' <input id="advActive" type="checkbox" ';
            if (data.adv_active) {
                userDetails += 'checked';
            }
            userDetails +=  '/> <span class="slider round"></span></label >'
                + ' <button onclick="" id="saveBtn" onclick="updateUser(' + userId + ')">UPDATE</button>'

            $("#userPopupWindow").html(userDetails);

        }, error: function () {
            alert("Something went wrong with Getting the User...");
            $("#editUser").dialog('close');
            $("#advFName").val("");
            $("#advSName").val("");
            $("#advEmail").val("");
            $("#advContact").val("");  
        },
    });  
}


function openReviewReport(rid) {



    $("#popUpReport").dialog('open');
}
