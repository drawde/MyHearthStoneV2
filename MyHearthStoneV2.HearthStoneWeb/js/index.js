$(function () {
    if (!!getUserCode()) {
        $("#userLabel li:first a:first").eq(0).html("欢迎回来，" + getNickName());
        $("#visitorLabel").fadeOut(1000, function () { $("#userLabel").fadeIn(1000) });
    }
});