function selectChal(data) {
    $("#ulBLChallenges").html($("#ulBLChallenges").html() + '<li class="dashPopupli liReport"><div class= "dashliInfo" >' +
        data.item.value + '</div >  </li >');
    console.log("yaaaas");
}