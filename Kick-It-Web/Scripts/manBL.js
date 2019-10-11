function selectChal(data) {
    $("#ulBLChallenges").html($("#ulBLChallenges").html() + '<li class="dashPopupli liReport"><div class= "dashliInfo" >' +
        data.item.value + '</div >  </li >');
    console.log("yaaaas");
}

function loadDivs() {
    var serviceURL = '/Home/Reports';
    $.ajax({
        url: serviceURL,
        async: true
    })
        .done(function (data) {
        
            console.log("1st");
            console.log(data);
        });

    $.ajax({
        url: "https://fiddle.jshell.net/favicon.png",
        async: true
    })
        .done(function (data) {
            console.log("2nd");
        });

    $.ajax({
        url: "https://fiddle.jshell.net/favicon.png",
        async: true
    })
        .done(function (data) {
            console.log("3rd");
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