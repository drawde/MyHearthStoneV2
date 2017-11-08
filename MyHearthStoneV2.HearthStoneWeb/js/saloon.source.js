$(function () {
    showLoader();
    var interval = setInterval(function () {
        if (!!apiTime && !!signObj) {
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
        var param = "{\"Name\":\"" + $("input[name='name']").val() + "\",\"Password\":\"" + $("input[name='password']").val() + "\",\"UserCode\":\"" + getUserCode() + "\"}";
        ajaxGetData("/Saloon/CreateOrUpdate", param, signObj, function (data) {
            showMessage(data.msg, function () {
                hideLoader();
                if (data.code == 100) {
                    window.location = "/Game/ChosenCardGroup?TableCode=" + data.data + "&password=" + $("input[name='password']").val();
                }
            });
        });

        return false;
    });
});
var PageNo = 1;
function getSaloons() {
    var param = "{\"PageSize\":\"10\",\"PageNo\":\"" + PageNo + "\"}";
    ajaxGetData("/Saloon/GetSaloons", param, signObj, function (data) {
        hideLoader();
        if (data.code == 100) {
            //console.log(data.Items);
            var needPassword = false;
            for (var i = 0; i < data.data.Items.length; i++) {
                if (!!data.data.Items[i].Password) {
                    needPassword = true;
                }
                $(".text-list").append("<div class=\"item\">" +
                    "<div class=\"description\">" +
                    "<h2><a href=\"javascript:zhanZuoEr(" + data.data.Items[i].ID + "," + needPassword + ");\">" + data.data.Items[i].TableName + "</a></h2>" +
                    "<p></p>" +
                    "<div class=\"meta\">" +
                    //"<ul class=\"tag-list\">" +
                    //"<li><a href=\"javascript:;\" class=\"btn btn-sm\">宝宝只想做个吃瓜群众</a></li>" +
                    //"</ul>" +
                    "</div>" +
                    "</div>" +
                    "<div class=\"action\">" +
                    "<a href=\"javascript:zhanZuoEr('" + data.data.Items[i].TableCode + "'," + needPassword + ");\" class=\"btn\">进入房间</a>" +
                    "</div>" +
                    "</div>");
            }
        }
    });
}

function zhanZuoEr(tableCode, needPassword) {
    if (needPassword) {
        showInput("请输入你的密码", "text", function (ipt) {
            goRoom(tableCode, ipt);
        });
    }
    else {
        goRoom(tableCode, '');
    }
}
function goRoom(tableCode, ipt) {
    showLoader();
    var param = "{\"TableCode\":\"" + tableCode + "\",\"UserCode\":\"" + getUserCode() + "\",\"Password\":\"" + ipt + "\"}";
    ajaxGetData("/Saloon/ZhanZuoEr", param, signObj, function (data) {
        hideLoader();
        if (data.code == 100) {
            window.location = "/Game/ChosenCardGroup?TableCode=" + tableCode + "&password=" + ipt;
        }
        else {
            showErrorMessage(data.msg);
        }
    });
}