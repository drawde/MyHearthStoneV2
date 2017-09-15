var handcardoffsets = [
    [25],
    [12.5, 32.5],
    [6.25, 22.5, 39],
    [2, 17, 32, 46],
    [0, 11, 25, 39, 55],
    [-12, 0, 14, 29, 44, 58],
    [-22, -5, 11, 26, 41, 55, 68],
    [-30, -15, 0, 15, 30, 45, 60, 75],
    [-35, -20, -5, 10, 25, 40, 55, 70, 85],
    [-40, -25, -10, 5, 20, 35, 50, 65, 80, 95],
];
$(function () {
    $("#Placeholder").val(getNickName());
    $("#MyClientName").html(getNickName());
    
    $(".CardPanel").click(function () {
        ChosenServant($(this));
    });
    if (!ISDEBUG) {
        eval($("#dst").val());
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

    resetHandCardStyle();

    $("#baraja-el li").mouseover(function () {
        cardOver(this);
    });
    $("#baraja-el li").mouseout(function () {
        cardOut(this);
    });
    //$("#baraja-el").shapeshift();

    bindDragCardEvent();

    bindCastCardEvent();

    $("#myTableCard li").mouseover(function () {
        bindTableCardOver(this);
    });
    $("#myTableCard li").mouseout(function () {        
        bindTableCardOunt(this);
    });
    $(document).bind("mousemove", function (e) {
        $(".arrow").css("left", e.pageX - 25).css("top", e.pageY - 25);
    });
});

//显示箭头图片
function showArrow() {        
    $(".arrow").show();
}

//隐藏箭头图片
function hideArrow() {
    $(".arrow").hide();    
}

//释放指向性技能（叫嚣的中士、黑翼腐蚀者、火球术）
function castDirectivitySpecialEffect(sourceCard) {
    showArrow();
    sourceCard.hide();
}

function resetHandCardStyle() {
    var $el = $('#baraja-el'),
        baraja = $el.baraja();
    baraja.fan({
        speed: 500,
        easing: 'ease-out',
        range: 12,
        origin: { x: 40, y: $("#baraja-el li").length * 130 },//1300
        center: true
    });
}

//绑定出牌事件
function bindCastCardEvent() {
    $("#myTableCard li img").droppable({
        accept: $("#baraja-el li"),
        drop: function (event, ui) {
            $(this).attr("src", $(ui.draggable).attr("cardImg"));
            $(this).attr("originalSrc", $(ui.draggable).attr("cardImg"));
            console.log("ok!");
            castDirectivitySpecialEffect($(ui.draggable));
        },
        out: function (event, ui) {
            console.log("out!");
            bindTableCardOunt($(this).parent());
        },
        over: function (event, ui) {
            console.log("over!");
            bindTableCardOver($(this).parent());
        }
    });
}

//绑定抓起牌事件
function bindDragCardEvent() {
    $("#baraja-el li").each(function () {
        $(this).draggable({
            revert: "invalid", appendTo: "body", cursorAt: { left: handcardoffsets[$("#baraja-el li").length - 1][$(this).index()], top: 25 },
            revertPosition: { left: 0, top: 0 },
            start: function () {
                console.log("start");
                $(this).css("width", "50px");
                $(this).css("height", "50px");
                $(this).html("<img src=\""+$(this).children().attr("src")+"\" />");
                $(this).css("top", "0px");
                $("#baraja-el li").unbind("mouseover");
                $("#baraja-el li").unbind("mouseout");
                //$("#myTableCard li").unbind("mouseover");
                //$("#myTableCard li").unbind("mouseout");

                //$("#myTableCard li").each(function () {
                //    bindTableCardOver(this);
                //});
            },
            stop: function () {
                $(this).html($(this).attr("originalCardHTML"));
                $("#baraja-el li").mouseover(function () {
                    cardOver(this);
                });
                $("#baraja-el li").mouseout(function () {
                    cardOut(this);
                });
                $(this).css("width", "150px");
                $(this).css("height", "250px");
                $(this).css("z-index", $(this).attr("zindex"));

                //$("#myTableCard li").mouseover(function () {
                //    bindTableCardOver(this);
                //});
                //$("#myTableCard li").mouseout(function () {
                //    bindTableCardOunt(this);
                //});
                //$("#myTableCard li").each(function () {
                //    bindTableCardOunt(this);
                //});
            }
        });
    });    
}

function bindTableCardOunt(card) {
    $(card).children().attr("src", $(card).children().attr("originalSrc"));
}

function bindTableCardOver(card) {
    if ($(card).children().attr("src") == "/images/cards/empty.png") {
        $(card).children().attr("src", "/images/cards/emptytablecard.png");
    }
}

//卡牌放大事件
function cardOver(card) {
    $(card).css("width", "200px");
    $(card).css("height", "310px");
    $(card).css("top", "-200px");
    $(card).css("z-index", 999999);
}

//卡牌大小位置还原事件
function cardOut(card) {
    $(card).css("width", "150px");
    $(card).css("height", "250px");
    $(card).css("top", "0px");
    $(card).css("left", "0px");
    $(card).css("z-index", $(card).attr("zindex"));
}

function ChosenServant(servantPannel) {
    if (!!servantPannel.attr("ServantCode") && servantPannel.attr("ServantCode") != "blank") {
        servantPannel.addClass("Active");
    }
}
function UnChosenServant() {
    $(".CardPanel").removeClass("Active");
}

$(function () {
    //$("#chatlayer").fadeIn();
    $.connection.hub.url = APIURL + "/signalr";
    $.connection.hub.start({ xdomain: true });
    //添加对自动生成的Hub的引用
    var chat = $.connection.chatHub;

    //调用Hub的callback回调方法

    //后端SendChat调用后，产生的addNewMessageToPage回调
    chat.client.addNewMessageToPage = function (id, name, message) {
        if (name == getNickName()) {
            $('#messages').append('<a href="javascript:;"><span>' + htmlEncode(name) + '：' + htmlEncode(message) + '</span></a>')
        }
        else {
            $('#messages').append('<a href="javascript:;" style="text-align:left"><span>' + htmlEncode(name) + '： ' + htmlEncode(message) + '</span></a>')
        }
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
        var username = getNickName();

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