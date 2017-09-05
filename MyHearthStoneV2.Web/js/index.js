$(function () {
    if (!!getUserCode()) {
        $("#userLabel li a").html("欢迎回来，" + getUserName());
        $("#visitorLabel").fadeOut(1000, function () { $("#userLabel").fadeIn(1000) });
    }
});