$(function () {
    if ($("#saveCardGroup")) {
        $("#saveCardGroup").click(saveCardGroup);
    }
    var interval = setInterval(function () {
        if (!!apiTime && !!signObj) {
            clearInterval(interval);
            getCards();
        }
    });
});
function saveCardGroup() {
    if (cardCount != 30) {
        showMessage("卡牌数量错误!"); return;
    }
    if (!!$("#cbp-spmenu-s2 h3 input").val() == false) {
        showMessage("请输入卡组名称!"); return;
    }
    showLoader();
    var cards = "";
    $("#cbp-spmenu-s2 [cardCode]").each(function () {
        if (!!cards) {
            cards = cards + ",";
        }
        var count = $(this).html();
        count = count.substr(count.lastIndexOf("X") + 1);
        cards = cards + $(this).attr("cardCode") + " X" + count;
    });
    var param = "{\"GroupName\":\"" + $("#cbp-spmenu-s2 h3 input").val() + "\",\"Cards\":\"" + cards + "\",\"UserCode\":\"" + getUserCode() + "\",\"GroupCode\":\"" + $("#GroupCode").val() + "\",\"Profession\":\"" + window.location.hash.substr(1) + "\"}";
    ajaxGetData("/Users/SaveCardGroup", param, signObj, function (data) {
        showMessage(data.msg, function () {
            hideLoader();
            if (data.code == 100) {
                window.location = "/UserCentre/MyCardGroups";
            }
        });
    });
}
function getCards() {
    var param = "{\"Profession\":\"" + window.location.hash.replace('#', '') + "\"}";
    ajaxGetData("/Cards/GetCard", param, signObj, function (data) {
        if (data.code == 100) {
            $("#cards").html("");
            $("#cards").append("<li>"+
                "<div class=\"details\">"+
                    "<h3>重新选择</h3>"+
                "</div>"+
                "<a class=\"more\" href=\"javascript:repick();\">"+
                    "<img src=\"/images/Druid.jpg\">"+
                "</a>"+
            "</li>");
            for (var i = 0; i < data.data.length; i++) {
                $("#cards").append("<li>"+
                        "<div class=\"details\">"+
                            "<h3>" + data.data[i].Name + "</h3>" +
                        "</div>"+
                        "<a class=\"more\" href=\"javascript:;\" cardCode=\"" + data.data[i].CardCode + "\" cardName=\"" + data.data[i].Name + "\">" +
                            "<img style=\"width: 290px;height: 200px\" src=\"/images/cards/texture/" + data.data[i].BackgroudImage + "\">" +
                        "</a>"+
                    "</li>");
            }
            $("#cards a[cardCode]").click(function () {
                pickCard($(this));
            });
        }
    });
}