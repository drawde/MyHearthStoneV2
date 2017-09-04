$(function () {
    $("#Placeholder").val(getNickName());
    $("#MyClientName").html(getNickName());
    
    $(".CardPanel").click(function () {
        ChosenServant($(this));
    });
    if (!ISDEBUG) {
        $("body").find("*").unbind("mousedown").bind("contextmenu", function (e) {
            e.preventDefault();
            return false;
        });
    }
    $("body").find("*").unbind("mousedown").bind("mousedown", function (event) {
        if (event.which == 3) {
            UnChosenServant();
        }
    });
    
    eval($("#dst").val());
});

function ChosenServant(servantPannel) {
    if (!!servantPannel.attr("ServantCode") && servantPannel.attr("ServantCode") != "blank") {
        servantPannel.addClass("Active");
    }
}
function UnChosenServant() {
    $(".CardPanel").removeClass("Active");
}

$(function () {
    $("#chatlayer").fadeIn();
    $.connection.hub.url = APIURL + "/signalr";
    $.connection.hub.start({ xdomain: true });
    //添加对自动生成的Hub的引用
    var chat = $.connection.chatHub;

    //调用Hub的callback回调方法

    //后端SendChat调用后，产生的addNewMessageToPage回调
    chat.client.addNewMessageToPage = function (id, name, message) {
        console.debug(message);
        $('#messages').append('<li style="color:blue;">' + htmlEncode(name) + '</li><li> ' + htmlEncode(message) + '</li>')
    };

    //后端SendLogin调用后，产生的loginUser回调
    chat.client.loginUser = function (userlist) {
        reloadUser(userlist);
    };

    //后端SendLogoff调用后，产生的logoffUser回调
    chat.client.logoffUser = function (userlist) {
        reloadUser(userlist);
    };

    $('#displayname').val(getNickName());

    //启动链接
    $.connection.hub.start().done(function () {

        var userid = getUserCode();//guid();
        var username = $('#displayname').val();

        //发送上线信息
        chat.server.sendLogin(userid, username);

        //点击按钮，发送聊天内容
        $('#send').click(function () {
            var chatContent = $('#message').val();
            chat.server.sendChat(userid, username, chatContent);
        });

        //点击按钮，发送用户下线信息
        $('#close').click(function () {
            chat.server.sendLogoff(userid, username);
            $("#send").css("display", "none");
        });

        //每隔5秒，发送心跳包信息
        setInterval(function () {
            chat.server.triggerHeartbeat(userid, username);
        }, 5000);
    });

});

//重新加载用户列表
var reloadUser = function (userlist) {
    $("#userList").children("li").remove();
    for (i = 0; i < userlist.length; i++) {
        $("#userList").append("<li>" + userlist[i].Name + "</li>");
    }
}

//div内容html化
var htmlEncode = function (value) {
    var encodedValue = $('<div />').html(value).html();
    return encodedValue;
}

//guid序号生成
var guid = (function () {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
                   .toString(16)
                   .substring(1);
    }
    return function () {
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
               s4() + '-' + s4() + s4() + s4();
    };
})();