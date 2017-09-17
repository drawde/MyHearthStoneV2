$(function () {
    showLoader();
    var interval = setInterval(function () {
        if (!!apiTime) {
            GetCardGroups();
            clearInterval(interval);
        }
    }, 100);
});

var PageNo = 1;
function GetCardGroups() {
    var sign = getSign();
    var param = "{\"PageSize\":\"999\",\"PageNo\":\"" + PageNo + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    ajaxGetData("/Users/GetCardGroups", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
        if (data.code == 100) {
            //console.log(data.Items);
            for (var i = 0; i < data.data.Items.length; i++) {
                $("#grid").append("<li><div class=\"details\" ><h3>" + data.data.Items[i].GroupName + "</h3></div >" +
                    "<a class=\"more\" href=\"#" + data.data.Items[i].Profession+"\">" +
                    "<img src=\"/images/" + data.data.Items[i].Profession+".jpg\"></a></li>");
            }
        }
    });
}