$(function () {
    showLoader();

    $.connection.hub.url = APIURL + "/signalr";
    $.connection.hub.start({ xdomain: true });
    if (window.location.pathname.toLowerCase() == "/game/chosencardgroup") {
        roomHub = $.connection.chosenCardGroupHub;
    }
    else if (window.location.pathname.toLowerCase() == "/game/battle") {
        roomHub = $.connection.battleHub;
    }
    //后端SendChat调用后，产生的addNewMessageToPage回调
    roomHub.client.addNewMessageToPage = function (name, message) {
        if (name == getNickName()) {
            $('#messages').append('<a href="javascript:;"  style="text-align:right"><span>' + name + '：' + message + '</span></a>');
        }
        else {
            $('#messages').append('<a href="javascript:;" style="text-align:left"><span>' + name + '： ' + message + '</span></a>');
            newMessageComing();
        }
    };
    roomHub.client.receiveBordcast = function (message, senderUserCode) {
        showInfoMessage(message);
    };
    
    registCustomRoomFunction();

    $.connection.hub.start().done(function () {
        var interval = setInterval(function () {
            if (!!apiTime && !!signObj) {
                clearInterval(interval);
                var param = "";
                if (window.location.pathname.toLowerCase() == "/game/chosencardgroup") {
                    param = "{\"NickName\":\"" + getNickName() + "\",\"TableCode\":\"" + getUrlParam("TableCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"Password\":\"" + getUrlParam("password") + "\"}";
                }
                else if (window.location.pathname.toLowerCase() == "/game/battle") {
                    param = "{\"NickName\":\"" + getNickName() + "\",\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\"}";
                }
                roomHub.server.online(appendParam(param, signObj)).done(function (res) {
                    res = JSON.parse(res);
                    hideLoader();
                    if (res.code == 100) {
                        showSuccessMessage("连接房间成功");
                        ClientConnected(res);
                        $('#send').click(function () {
                            var chatContent = $('#message').val();
                            roomHub.server.sendChat(getUserCode(), chatContent, getUrlParam("TableCode"));
                        });
                    }
                    else {
                        showErrorMessage(res.msg);
                    }
                });
            }
        }, 100);
    });
});

var unReadMessageCount = 0;
function newMessageComing() {
    if ($(".menu-wrap").is(":hidden")) {
        unReadMessageCount = unReadMessageCount + 1;
        $("#open-button").addClass("shaking");
        $(".unread").html(unReadMessageCount);        
        setTimeout(function () {
            $("#open-button").removeClass("shaking");
        }, 1500);
    }
}

function clearUnReadMessage() {
    unReadMessageCount = 0;
    $("#open-button").removeClass("shaking");
    $(".unread").html("");
}

window.onbeforeunload = function () {
    var param = "{\"TableCode\":\"" + getUrlParam("TableCode") + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    roomHub.server.leaveRoom(appendParam(param, signObj));
}
