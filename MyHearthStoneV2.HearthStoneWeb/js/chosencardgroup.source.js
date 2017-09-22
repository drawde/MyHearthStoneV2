var roomHub;
var roomcount = 0;

function ClientConnected() {
    GetCardGroups();    
}
function IAmReady(groupCode) {
    var param = "{\"TableID\":\"" + getUrlParam("saloonid") + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    roomHub.server.iAmReady(appendParam(param, getSign()));
}
function registCustomRoomFunction() {
    roomHub.client.receiveOnlineNotice = function (name, message) {
        if (name != getNickName()) {
            showInfoMessage(message);
        }
    };
    roomHub.client.receiveReadyNotice = function (message, senderUserCode) {
        if (senderUserCode != getUserCode()) {
            showInfoMessage(message);
        }
    };
}

var PageNo = 1;
function GetCardGroups() {
    var sign = getSign();
    var param = "{\"PageSize\":\"999\",\"PageNo\":\"" + PageNo + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    ajaxGetData("/Users/GetCardGroups", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
        if (data.code == 100) {
            for (var i = 0; i < data.data.Items.length; i++) {
                $("#grid").append("<li><div class=\"details\" ><h3>" + data.data.Items[i].GroupName + "</h3></div>" +
                    "<a class=\"more\" href=\"javascript:IAmReady('" + data.data.Items[i].GroupCode + "');\">" +
                    "<img src=\"/images/" + data.data.Items[i].Profession + ".jpg\"></a></li>");
            }
        }
    });
}