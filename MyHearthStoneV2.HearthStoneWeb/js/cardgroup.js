$(function () {
    $("#grid a").click(function () {
        $("#grid").fadeOut(500, function () { $("#cards").fadeIn(500); classie.toggle(document.getElementById('cbp-spmenu-s2'), 'cbp-spmenu-open'); });
    });
    
    if (!!groupCode) {
        $("#grid").fadeOut(500, function () { $("#cards").fadeIn(500); classie.toggle(document.getElementById('cbp-spmenu-s2'), 'cbp-spmenu-open'); });
    }
});
function repick() {
    $("#cards").fadeOut(500, function () { $("#grid").fadeIn(500); classie.toggle(document.getElementById('cbp-spmenu-s2'), 'cbp-spmenu-open'); });
}
var cardCount = 0;
function pickCard(a) {
    if (cardCount >= 30) {
        showMessage("卡组最多只能有30张牌");
        return;
    }
    var count = 1;
    if ($("#cbp-spmenu-s2 [cardCode='" + a.attr("cardCode") + "']").length > 0) {
        count = $("#cbp-spmenu-s2 [cardCode='" + a.attr("cardCode") + "']").html();
        count = count.substr(count.lastIndexOf("X") + 1);
        count = parseInt(count) + 1;
        $("#cbp-spmenu-s2 [cardCode='" + a.attr("cardCode") + "']").html(a.attr("cardName") + "X" + count);
    }
    else {
        $("#cbp-spmenu-s2 h3").after("<a href=\"javascript:removeCard('" + a.attr("cardCode") + "');\" cardCode=\"" + a.attr("cardCode") + "\">" + a.attr("cardName") + " X1</a>");
    }
    cardCount = cardCount + 1;
}
function removeCard(cardCode) {
    var count = $("#cbp-spmenu-s2 [cardCode='" + cardCode + "']").html();
    count = count.substr(count.lastIndexOf("X") + 1);
    if (count == 1) {
        $("#cbp-spmenu-s2 [cardCode='" + cardCode + "']").remove();
    }
    else {
        count = parseInt(count) - 1;
        var cardName = $("#cbp-spmenu-s2 [cardCode='" + cardCode + "']").html();
        $("#cbp-spmenu-s2 [cardCode='" + cardCode + "']").html(cardName.substr(0, cardName.lastIndexOf("X")) + " X" + count);
    }
    cardCount = cardCount - 1;
}

