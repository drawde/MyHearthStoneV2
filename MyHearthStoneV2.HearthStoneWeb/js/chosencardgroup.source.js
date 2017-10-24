var roomHub;
var roomcount = 0;

function ClientConnected() {
    GetCardGroups();    
}
function IAmReady(groupCode) {
    var param = "{\"TableCode\":\"" + getUrlParam("TableCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"CardGroupCode\":\"" + groupCode + "\",\"NickName\":\"" + getNickName() + "\"}";
    roomHub.server.iAmReady(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);

    });;
}
function registCustomRoomFunction() {
    roomHub.client.receiveOnlineNotice = function (message, user) {
        showInfoMessage(message);
        user = JSON.parse(user);
        if (user.UserCode != getUserCode()) {            
            //classie.toggle(document.getElementById('cbp-spmenu-s2'), 'cbp-spmenu-open'); 
            //$("#cbp-spmenu-s2").html("<h3>"+user.NickName+"</h3>");
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
    var param = "{\"PageSize\":\"999\",\"PageNo\":\"" + PageNo + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    ajaxGetData("/Users/GetCardGroups", param, signObj, function (data) {
        if (data.code == 100) {
            for (var i = 0; i < data.data.Items.length; i++) {
                $("#grid").append("<li><div class=\"details\" ><h3>" + data.data.Items[i].GroupName + "</h3></div>" +
                    "<a class=\"more\" href=\"javascript:IAmReady('" + data.data.Items[i].GroupCode + "');\">" +
                    "<img src=\"/images/" + data.data.Items[i].Profession + ".jpg\"></a></li>");
            }
        }
    });
}