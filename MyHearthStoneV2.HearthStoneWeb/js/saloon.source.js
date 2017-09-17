$(function () {
    showLoader();
    var interval = setInterval(function () {
        if (!!apiTime) {
            getSaloons();
            clearInterval(interval);
        }
    }, 100);
    
    $("#createsaloonFrom").submit(function () {
        if (!!$("input[name='name']").val() == false) {
            showMessage("请输入房间名");
            return false;
        }
        showLoader();
        var sign = getSign();
        var param = "{\"Name\":\"" + $("input[name='name']").val() + "\",\"Password\":\"" + $("input[name='password']").val() + "\",\"UserCode\":\"" + getUserCode() + "\"}";
        ajaxGetData("/Saloon/CreateOrUpdate", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
            showMessage(data.msg, function () {
                hideLoader();
                if (data.code == 100) {
                    window.location = "/game/saloon";
                }
            });
        });
        
        return false;
    });    
});
var PageNo = 1;
function getSaloons() {
    
    var sign = getSign();
    var param = "{\"PageSize\":\"10\",\"PageNo\":\"" + PageNo + "\"}";
    ajaxGetData("/Saloon/GetSaloons", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
        hideLoader();
        if (data.code == 100) {
            //console.log(data.Items);
            for (var i = 0; i < data.data.Items.length; i++) {
                $(".text-list").append("<div class=\"item\">" +
                    "<div class=\"description\">" +
                    "<h2><a href=\"/Game/ChosenCardGroup?saloonid=" + data.data.Items[i].ID + "\">" + data.data.Items[i].TableName + "</a></h2>" +
                    "<p></p>" +
                    "<div class=\"meta\">" +
                    "<ul class=\"tag-list\">" +
                    "<li><a href=\"javascript:;\" class=\"btn btn-sm\">宝宝只想做个吃瓜群众</a></li>" +
                    "</ul>" +
                    "</div>" +
                    "</div>" +
                    "<div class=\"action\">" +
                    "<a href=\"/Game/ChosenCardGroup?saloonid=" + data.data.Items[i].ID + "\" class=\"btn\">进入房间</a>" +
                    "</div>" +
                    "</div>");
            }
        }
    });
}