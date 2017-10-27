var roomHub;
var roomcount = 0;
var intervalNickName;
var pointCount = 3;
function ClientConnected(res) {
    GetCardGroups();    
    if (res.code == 100) {
        if (res.data.CreateUserCode == getUserCode() && res.data.CreateUserIsReady) {
            ShowWaitFrame();
        }
        else if (res.data.PlayerUserCode == getUserCode() && res.data.PlayerIsReady) {
            ShowWaitFrame();
        }
    }
}
function ShowWaitFrame() {
    if (!!intervalNickName) {
        clearInterval(intervalNickName);
    }
    $("#grid").fadeOut(500, function () {
        intervalNickName = setInterval(function () {
            var points = ".";            
            if (pointCount == 3) {
                points = "...";
                pointCount = 0;
            }
            else if (pointCount == 2) {
                points = "..";
            }
            pointCount += 1;
            $("#cards .details h3").html("等待对方选择卡组" + points);
        }, 1000); $("#cards").fadeIn(500);
    });
}
function repick() {
    var param = "{\"TableCode\":\"" + getUrlParam("TableCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"NickName\":\"" + getNickName() + "\"}";
    roomHub.server.repick(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);
        if (res.code == 100) {
            if (!!intervalNickName) {
                clearInterval(intervalNickName);
            }
            $("#cards").fadeOut(500, function () { $("#grid").fadeIn(500); });
        }
    });    
}
function IAmReady(groupCode) {
    var param = "{\"TableCode\":\"" + getUrlParam("TableCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"CardGroupCode\":\"" + groupCode + "\",\"NickName\":\"" + getNickName() + "\"}";
    roomHub.server.iAmReady(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);
        if (res.code == 100) {
            ShowWaitFrame(res.data);
        }
    });
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

    roomHub.client.go = function (message, senderUserCode) {
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