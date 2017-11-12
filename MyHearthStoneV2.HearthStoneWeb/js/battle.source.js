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
var switchCardIndexs = [];
function registCustomRoomFunction() {
}
function ClientConnected(res) {
    if (res.code == 100) {        
        var initCards = Enumerable.From(res.data.Players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
        if (initCards.InitCards && initCards.InitCards.length > 0) {
            ShowSwitchPanel(initCards.InitCards);
        }
    }
}

//初始化开局选牌面板
function ShowSwitchPanel(initCards) {
    var idx = 0;
    var html = "<div class=\"container\"><div class=\"switchpanel\">";
    Enumerable.From(initCards).ForEach(function (value, index) {
        html += "<a href=\"javascript:ChoseSwitchCard(" + index + ");\" class=\"main_img\">" +
            "<img src=\"/images/SwitchCardPanel/teacher0" + (index + 1) + "1.jpg\">" +
            "<div class=\"main_info\">" +
                "<div class=\"info\">" +
                    "<h2>" + value.Name + "</h2>" +
                    "<p></p>" +
                "</div>" +
                "<div class=\"info_more\">" +
                    "<p>" + dialogues[Math.round(Math.random() * (dialogues.length - 1))] + "</p>" +
                "</div>" +
            "</div>" +
        "</a>";
    });
    html += "</div><div class=\"switchdone\"><a href=\"javascript:switchDone();\">asdasdasd</a></div></div>";
    $(".arrow").before(html);
    //while (idx < 5) {        
    //    idx++;
    //    $(".switchpanel").children().eq(idx).hide();        
    //}
    var $img = $(".switchpanel>.main_img");
    var speed = 300;

    $img.hover(function () {
        $(this).find(".main_info").stop().animate({ "top": "0px" }, speed)
              .find(".info_more>p").fadeIn(500);
    }, function () {
        $(this).find(".main_info").stop().animate({ "top": "285px" }, speed)
              .find(".info_more>p").fadeOut(500);
    });
    $(".container").show();
}

function switchDone(){
    var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"SwitchCards\":\"" + switchCardIndexs.toString() + "\"}";
    roomHub.server.switchCard(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);
        console.log(res);
        if (res.code == 100) {
            
        }
    });
}
//选择一张开局要换的牌
function ChoseSwitchCard(switchCardIndex) {
    if (Enumerable.From(switchCardIndexs).Any(c=>c == switchCardIndex)) {
        switchCardIndexs = switchCardIndexs.splice(switchCardIndex, 1);
        $(".switchpanel a").eq(switchCardIndex).css("width", "196px");
        $(".switchpanel a").eq(switchCardIndex).css("height", "400px");
        $(".switchpanel a").eq(switchCardIndex).hover(function () {
            $(this).find(".main_info").stop().animate({ "top": "0px" }, 300)
                  .find(".info_more>p").fadeIn(500);
        }, function () {
            $(this).find(".main_info").stop().animate({ "top": "285px" }, 300)
                  .find(".info_more>p").fadeOut(500);
        });
        //console.log("da");
    }
    else {
        switchCardIndexs.push(switchCardIndex);        
        $(".switchpanel a").eq(switchCardIndex).css("width", "185px");
        $(".switchpanel a").eq(switchCardIndex).css("height", "380px");
        $(".switchpanel a").eq(switchCardIndex).unbind();
        //console.log("xiao");
    }
    switchCardIndexs.sort();
    //console.log(switchCardIndexs);
}
$(function () {
    $("#Placeholder").val(getNickName());
    $("#MyClientName").html(getNickName());
    
    //$(".CardPanel").click(function () {
    //    ChosenServant($(this));
    //});
    //if (!ISDEBUG) {
    //    eval($("#dst").val());
    //    $("body").find("*").unbind("mousedown").bind("contextmenu", function (e) {
    //        e.preventDefault();
    //        return false;
    //    });
    //}
    $("body").find("*").unbind("mousedown").bind("mousedown", function (event) {
        if (event.which == 3) {
            //UnChosenServant();
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