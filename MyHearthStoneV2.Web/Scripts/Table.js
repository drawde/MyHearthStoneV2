$(function () {
    $(".CardPanel").click(function () {
        ChosenServant($(this));
    });
    if (!ISDEBUG) {
        $("body").find("*").unbind("mousedown").bind("contextmenu", function (e) {
            e.preventDefault();
            return false;
        });
    }
    $("body").find("*").unbind("mousedown").bind("mousedown", function (event) {
        if (event.which == 3) {
            UnChosenServant();
        }
    });
});

function ChosenServant(servantPannel) {
    if (!!servantPannel.attr("ServantCode") && servantPannel.attr("ServantCode") != "blank") {
        servantPannel.addClass("Active");
    }
}
function UnChosenServant() {
    $(".CardPanel").removeClass("Active");
}