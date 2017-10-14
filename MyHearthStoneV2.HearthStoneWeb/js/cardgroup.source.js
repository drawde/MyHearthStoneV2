$(function () {
    if ($("#saveCardGroup")) {
        $("#saveCardGroup").click(saveCardGroup);
    }
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