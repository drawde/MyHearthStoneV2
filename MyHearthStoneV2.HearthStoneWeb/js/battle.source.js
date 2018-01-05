var joke = ["时空枢纽收到干扰，你已进入断层空间", "给你讲个笑话，爸爸教你玩游戏", "我认为这非常cooooooooool！", "净化这张卡还是有1%的玩家在使用的，所以不算完全失败", "我们经历了上百次严谨的测试，决定将战歌指挥官改为你的冲锋随从获得+1攻击力", "我们削弱乱舞是因为它限制了盗贼强力武器的设计", "我们知道青玉护符这张卡一旦放出来就会产生巨大争议，但我们认为这很cooooooool", "经典包将永不退环境"];
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

var heroPowerImage = "/images/game/texture/hero/heropower/";
var switchCardIndexs = [];
var originalCard = { width: "150px", height: "250px" };
//指向性技能的目标
var targetIndex = -1;
//当抓起一张牌时，是否用了右键扔掉这张牌
var isDropped = false;
function registCustomRoomFunction() {
    roomHub.client.queryMyCards = queryMyCards;
    
    //被动刷新当前游戏环境
    roomHub.client.resetGameContext = function (res, createUserCode) {
        console.log(createUserCode);
        res = JSON.parse(res);
        if(createUserCode!= getUserCode() && res.code == 100){
            //如果当前用户不是刷新操作的发起人，则刷新游戏环境                        
            console.log("resetGameContext");
            var currentUser = Enumerable.From(res.data.Players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
            if (currentUser.IsActivation) {
                //如果当前回合为当前用户，则发起回合开始的动作
                var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\"}";
                roomHub.server.turnStart(appendParam(param, signObj)).done(function (result) {
                    result = JSON.parse(result);
                    console.log("turnStart");
                    if (result.code == 100) {
                        console.log(result);
                        resetHandCards(result.data.Players);
                        setPowerPanel(result.data.Players);
                        setDeskCard(result.data.Players);
                        showSuccessMessage("回合开始");
                    }
                    else {
                        showErrorMessage("时空枢纽收到干扰，你已进入断层空间");
                    }
                    hideLoader();
                });
            }
            else {
                resetHandCards(res.data.Players);
                setPowerPanel(res.data.Players);
                setDeskCard(res.data.Players);
            }
        }
    };
}
function ClientConnected(res) {
    console.log(res);
    if (res.code == 100) {        
        var initCards = Enumerable.From(res.data.Players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
        setPowerPanel(res.data.Players);
        if (res.data.TurnIndex == 0) {            
            ShowSwitchPanel(initCards.InitCards);
        }
        else {
            var currentPlayer = Enumerable.From(res.data.Players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();                        
            resetHandCards(res.data.Players);
            var baseIdx = 1;
            if (currentPlayer.IsFirst) {
                $("#myTableCard li").each(function (idx) {
                    $(this).attr("DeskCardIndex", baseIdx);
                    baseIdx++;
                });
                baseIdx++;
                $("#otherTableCard li").each(function (idx) {
                    $(this).attr("DeskCardIndex", baseIdx);
                    baseIdx++;
                });
            }
            else {
                $("#otherTableCard li").each(function (idx) {
                    $(this).attr("DeskCardIndex", baseIdx);
                    baseIdx++;
                });
                baseIdx++;
                $("#myTableCard li").each(function (idx) {
                    $(this).attr("DeskCardIndex", baseIdx);
                    baseIdx++;
                });
            }
            $("#myTableCard li").mouseover(function () {
                bindTableCardOver(this);
            });
            $("#myTableCard li").mouseout(function () {
                bindTableCardOut(this);
            });
            $(document).bind("mousemove", function (e) {
                $(".cardDetail").css("left", e.pageX + 60).css("top", e.pageY - 60);
            });
            if (currentPlayer.IsActivation) {                
                
            }
            setDeskCard(res.data.Players);
        }
    }
}

//初始化开局选牌面板
function ShowSwitchPanel(initCards) {
    var idx = 0;
    var html = "<div class=\"container\"><div class=\"switchpanel\">";
    Enumerable.From(initCards).ForEach(function (value, index) {
        html += "<a href=\"javascript:ChoseSwitchCard(" + index + ");\" class=\"main_img\">" +
            "<img src=\"" + cardBackgroupImage + value.BackgroudImage + "\">" +
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
    html += "</div><div class=\"switchdone\"><a href=\"javascript:switchDone();\"><img src=\"/images/tables/btn/switchCard.png\" style=\"width:144px;height:70px;margin-top:10px;\" /></a></div></div>";
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

    $(".container").fadeIn(500);
}

function switchDone() {
    showLoader();
    var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"SwitchCards\":\"" + switchCardIndexs.toString() + "\"}";
    roomHub.server.switchCard(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);        
        if (res.code == 100) {
            Enumerable.From(res.data.HandCards).ForEach(function (value, index) {
                $(".switchpanel h2").eq(index).html(value.Name);
                $(".switchpanel a").eq(index).find(".info_more p").html(dialogues[Math.round(Math.random() * (dialogues.length - 1))]);
                $(".switchpanel a").eq(index).css("width", "196px");
                $(".switchpanel a").eq(index).css("height", "400px");
                $(".switchpanel a").eq(index).hover(function () {
                    $(this).find(".main_info").stop().animate({ "top": "0px" }, 300)
                          .find(".info_more>p").fadeIn(500);
                }, function () {
                    $(this).find(".main_info").stop().animate({ "top": "285px" }, 300)
                          .find(".info_more>p").fadeOut(500);
                });
            });
            $(".switchdone").fadeOut(500);
            //resetHandCards(res.data);
            switchCardIndexs = [];
        }
        else {
            showErrorMessage("时空枢纽收到干扰，你已进入断层空间");
        }
        hideLoader();
    });
}
//选择一张开局要换的牌
function ChoseSwitchCard(switchCardIndex) {
    if (Enumerable.From(switchCardIndexs).Any(c => c == switchCardIndex)) {
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

//获取当前游戏最新信息
function queryMyCards() {
    //showLoader();
    var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    roomHub.server.getMyCards(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);        
        //console.log(res);
        if (res.code == 100) {
            $(".container").fadeOut(500);
            $(".switchdone").fadeOut(500);
            //var currentPlayer = Enumerable.From(res.data.Players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
            resetHandCards(res.data.Players);
            setPowerPanel(res.data.Players);
            //如果是刚开局换完牌，初始化棋盘对象事件
            if (res.data.TurnIndex == 1) {
                switchCardIndexs = [];
                $("#myTableCard li").mouseover(function () {
                    bindTableCardOver(this);
                });
                $("#myTableCard li").mouseout(function () {
                    bindTableCardOut(this);
                });
                //$(document).bind("mousemove", function (e) {
                    //$(".arrow").css("left", e.pageX - 25).css("top", e.pageY - 25);
                //});
            }
            setDeskCard(res.data.Players);
        }
        else {
            showErrorMessage("时空枢纽收到干扰，你已进入断层空间");
        }
        //hideLoader();
    });
}

//设置双方的法力值
function setPowerPanel(players) {    
    var currentPlayer = Enumerable.From(players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
    $(".CurrentPowerPanel").html("");
    if (currentPlayer.Power > 0) {
        for (var i = 0; i < currentPlayer.Power; i++) {
            if (i <= currentPlayer.Power) {
                $(".CurrentPowerPanel").append("<li class=\"Power\"></li>");
            }
            else {
                $(".CurrentPowerPanel").append("<li class=\"EmptyPower\"></li>");
            }
        }
    }
    else {
        $(".CurrentPowerPanel").append("<li class=\"EmptyPower\"></li>");
    }
    var enemyPower = Enumerable.From(players).Where("x=>x.UserCode!='" + getUserCode() + "'").First().Power;
    $(".EnemyPowerPanel").removeClass().addClass("EnemyPowerPanel Power" + enemyPower);
}
$(function () {
    $("#Placeholder").val(getNickName());
    $("#MyClientName").html(getNickName());
    $("body").find("*").unbind("mousedown").bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("right");
        hideArrow();
        return false;
    });
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

    //$(".arrow").click(function (e) {        
        //console.log($(e.target).html());
        //hideArrow();
    //}); 

});

//显示箭头图片
function showArrow(card, deskIndex) {
    //$(".content-wrap").css("cursor", "crosshair");
    $("#otherTableCard li").css("cursor", "crosshair");
    $("#myTableCard li").css("cursor", "crosshair");
    $("#otherTableCard li").click(function (e) {
        //console.log($(e.target).parent().attr("deskcardindex"));
        targetIndex = $(e.target).parent().attr("deskcardindex");
        if ($("#otherTableCard li[deskcardindex='" + targetIndex + "']").attr("card")) {
            hideArrow(card, deskIndex);
        }
    });
    $("#myTableCard li").click(function (e) {
        //console.log($(e.target).parent().attr("deskcardindex"));
        targetIndex = $(e.target).parent().attr("deskcardindex");
        //console.log($("#myTableCard li[deskcardindex='" + targetIndex + "']").attr("card"));
        if ($("#myTableCard li[deskcardindex='" + targetIndex + "']").attr("card")) {
            hideArrow(card, deskIndex);
        }
    });
}

//隐藏箭头图片
function hideArrow(card, deskIndex) {
    //console.log(32213);
    $("#otherTableCard li").unbind();
    $("#myTableCard li").unbind();
    $("#otherTableCard li").css("cursor", "default");
    $("#myTableCard li").css("cursor", "default");

    console.log("deskIndex:" + deskIndex);
    console.log("targetIndex:" + targetIndex);
    if (card) {
        if (card.CardType == CardType.随从) {
            castServant(card, deskIndex, targetIndex);
        }
        else if (card.CardType == CardType.法术) {
            castSpell(card, targetIndex);
        }
    }
    //$(".arrow").hide();    
}

//释放指向性技能（叫嚣的中士、黑翼腐蚀者、火球术）
function castDirectivityAbility(sourceCard, deskIndex) {
    var dragCard = JSON.parse(decodeURI($(sourceCard).attr("Card")));
    //console.log(dragCard);
    showArrow(dragCard, deskIndex);
    sourceCard.hide();
}

//重置并更新手牌
function resetHandCards(players) {
    $("#baraja-el").html("");
    var currentPlayer = Enumerable.From(players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
    Enumerable.From(currentPlayer.HandCards).ForEach(function (value, index) {
        var cast_Crosshair_Style = CastCrosshairStyle.无;
        cast_Crosshair_Style = Enumerable.From(value).Any(c => Enumerable.From(c.Abilities).Any(x => x.CastCrosshairStyle == CastCrosshairStyle.单个)) ? CastCrosshairStyle.单个 : CastCrosshairStyle.无;
        //$("#baraja-el").append("<li CastCrosshairStyle=\"" + cast_Crosshair_Style + "\" Cost=\"" + value.Cost + "\" cardImg=\"" + cardBackgroupImage + value.BackgroudImage + "\" CardType=\"" + value.CardType + "\" Card=\"" + encodeURI(JSON.stringify(value)) + "\" originalCardHTML=\"" + cardBackgroupImage + value.BackgroudImage + "\" />" +
        //    "<h4>" + value.Name + "</h4><p>Total bicycle rights in blog four loko raw denim ex, helvetica sapiente odio placeat.</p>" +
        //    "<img src=\"" + cardBackgroupImage + value.BackgroudImage + "\" /><h4>" + value.Name + "</h4>" +
        //    "<p></p></li>");
        $("#baraja-el").append("<li CastCrosshairStyle=\"" + cast_Crosshair_Style + "\" Cost=\"" + value.Cost + "\" cardImg=\"" + cardBackgroupImage + value.BackgroudImage + "\" CardType=\"" + value.CardType + "\" Card=\"" + encodeURI(JSON.stringify(value)) + "\" originalCardHTML='<img src=\"" + cardBackgroupImage + value.BackgroudImage + "\" />" +
            "<h4>" + value.Name + "</h4><p>Total bicycle rights in blog four loko raw denim ex, helvetica sapiente odio placeat.</p>'>" +
            "<img src=\"" + cardBackgroupImage + value.BackgroudImage + "\" /><h4>" + value.Name + "</h4>" +
            "<p></p></li>");
    });
    var $el = $('#baraja-el'),
        baraja = $el.baraja();
    baraja.fan({
        speed: 500,
        easing: 'ease-out',
        range: 12,
        origin: { x: 40, y: $("#baraja-el li").length * 130 },//1300
        center: true
    });
    $("#baraja-el li").each(function () {
        $(this).attr("zindex", $(this).css("z-index"));
        //如果当前费用够打出这张牌，则把牌的样式设置为高亮
        if(parseInt($(this).attr("Cost")) <= currentPlayer.Power && currentPlayer.IsActivation){
            $(this).addClass("ActiveCard");
        }
    });    
    $("#baraja-el li").mouseover(function () {
        cardOver(this);
    });
    $("#baraja-el li").mouseout(function () {
        cardOut(this);
    });
    if (currentPlayer.IsActivation) {
        //$("#baraja-el").shapeshift();
        
        $("#btnTurnEnd img").attr("src", "/images/tables/btn/roundEndOK.png");
        $("#btnTurnEnd").click(TurnEnd);
        bindDragCardEvent();
        bindCastServantEvent();
    }
    else {
        $("#btnTurnEnd").unbind();
        $("#btnTurnEnd img").attr("src", "/images/tables/btn/roundEnd.png");
    }
}

//回合结束事件
function TurnEnd() {
    var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\"}";
    roomHub.server.turnEnd(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);
        if (res.code == 100) {
            console.log(res);
            resetHandCards(res.data.Players);
            setPowerPanel(res.data.Players);
            setDeskCard(res.data.Players);
        }
        else {
            showErrorMessage("时空枢纽收到干扰，你已进入断层空间");
        }
        hideLoader();
    });
}
//绑定随从进场事件
function bindCastServantEvent() {
    $("#myTableCard li img").droppable({
        accept: $("#baraja-el li[CardType=" + CardType.随从 + "]"),
        drop: function (event, ui) {
            if (event.button == 0 && isDropped == false) {
                $(this).attr("src", $(ui.draggable).attr("cardImg"));
                $(this).attr("originalSrc", $(ui.draggable).attr("cardImg"));
                var dragCard = JSON.parse(decodeURI($(ui.draggable).attr("Card")));
                var deskIndex = $(this).parent().attr("deskcardindex");
                //console.log($(this).parent().attr("deskcardindex"));

                //如果抓起的牌的技能需要指定一个目标，就显示一个准心让玩家指定目标，然后打出这张牌
                //只有指向性随从进场才会执行下面的方法
                if (Enumerable.From(dragCard.Abilities).Any(c => c.CastCrosshairStyle == CastCrosshairStyle.单个)) {
                    console.log("castDirectivityAbility2");
                    console.log(deskIndex);
                    castDirectivityAbility($(ui.draggable), deskIndex);
                }
                else if (dragCard) {                    
                    castServant(dragCard, $(this).parent().attr("deskcardindex"), targetIndex);
                }                
            }
            else {

            }
            console.log("ok!");
        },
        out: function (event, ui) {
            console.log("out!");
            bindTableCardOut($(this).parent());
        },
        over: function (event, ui) {
            console.log("over!");
            bindTableCardOver($(this).parent());
        }
    });
}
var hh;
//绑定抓起牌事件
function bindDragCardEvent() {
    $("#baraja-el li").each(function () {
        $(this).draggable({
            revert: "invalid", appendTo: "body", cursorAt: { left: handcardoffsets[$("#baraja-el li").length - 1][$(this).index()], top: 25 },
            revertPosition: { left: 0, top: 0 },
            start: function () {
                //console.log(JSON.parse(decodeURI($(this).attr("Card"))));
                isDropped = false;
                console.log("start");
                var dragCard = JSON.parse(decodeURI($(this).attr("Card")));

                //如果抓起的牌是法术牌，并且需要指定一个目标，就显示一个准心让玩家指定目标，然后打出这张牌
                //只有法术牌才会执行下面的方法
                if (dragCard.CardType == CardType.法术 && Enumerable.From(dragCard.Abilities).Any(c => c.CastCrosshairStyle == CastCrosshairStyle.单个)) {
                    console.log("castDirectivityAbility1");
                    castDirectivityAbility($(this), -1);
                }
                $(this).css("width", "50px");
                $(this).css("height", "50px");
                $(this).html("<img src=\"" + $(this).children("img").attr("src") + "\" />");
                $(this).css("top", "0px");
                $(this).mousedown(function (e) {
                    if (e.which == 3) {
                        $(this).html($(this).attr("originalCardHTML"));
                        $(this).show();
                        isDropped = true;
                        $(this).css("width", originalCard.width);
                        $(this).css("height", originalCard.height);
                        $(this).css("z-index", $(this).attr("zindex"));
                    }
                });
                $("#baraja-el li").unbind("mouseover");
                $("#baraja-el li").unbind("mouseout");
                //$("#myTableCard li").unbind("mouseover");
                //$("#myTableCard li").unbind("mouseout");

                //$("#myTableCard li").each(function () {
                //    bindTableCardOver(this);
                //});
            },
            stop: function (event, ui) {
                
                //hideArrow();
                $("#baraja-el li").mouseover(function () {
                    cardOver(this);
                });
                $("#baraja-el li").mouseout(function () {
                    cardOut(this);
                });
                if (event.button == 0) {
                    var card = JSON.parse(decodeURI($(this).attr("Card")));

                    //如果抓起的牌有指向性技能，则不执行出牌方法，因为前面已经执行过了
                    //实际上这里只有非指向性的法术牌才需要执行下面的方法
                    if (Enumerable.From(card.Abilities).Any(c => c.CastCrosshairStyle == CastCrosshairStyle.单个) == false && isDropped == false) {
                        console.log("stopstop");
                        if (card.CardType == CardType.法术) {
                            castSpell(card, targetIndex);
                            $(this).hide();
                        }                        
                    }
                }
                else {
                    $(this).html($(this).attr("originalCardHTML"));
                    $(this).show();
                    
                    $(this).css("width", originalCard.width);
                    $(this).css("height", originalCard.height);
                    $(this).css("z-index", $(this).attr("zindex"));
                }

                //$("#myTableCard li").mouseover(function () {
                //    bindTableCardOver(this);
                //});
                //$("#myTableCard li").mouseout(function () {
                //    bindTableCardOut(this);
                //});
                //$("#myTableCard li").each(function () {
                //    bindTableCardOut(this);
                //});
            }
        });
    });    
}

//打出一张法术牌
function castSpell(spell, Target) {
    var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"CardInGameCode\":\"" + spell.CardInGameCode + "\",\"Target\":\"" + Target + "\"}";
    roomHub.server.castSpell(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);
        if (res.code == 100) {
            console.log(res);
            resetHandCards(res.data.Players);
            setPowerPanel(res.data.Players);
            setDeskCard(res.data.Players);
        }
        else {
            showErrorMessage("时空枢纽收到干扰，你已进入断层空间");
        }
        hideLoader();
    });
}

//打出一张随从牌
function castServant(spell, Location, Target) {
    var param = "{\"GameCode\":\"" + getUrlParam("GameCode") + "\",\"UserCode\":\"" + getUserCode() + "\",\"CardInGameCode\":\"" + spell.CardInGameCode + "\",\"Target\":\"" + Target + "\",\"Location\":\"" + Location + "\"}";
    roomHub.server.castServant(appendParam(param, signObj)).done(function (res) {
        res = JSON.parse(res);
        if (res.code == 100) {
            console.log(res);
            resetHandCards(res.data.Players);
            setPowerPanel(res.data.Players);
            setDeskCard(res.data.Players);
        }
        else {
            showErrorMessage("时空枢纽收到干扰，你已进入断层空间");
        }
        hideLoader();
    });
}

function bindTableCardOut(card) {
    if ($(card).children("img").attr("src") == "/images/cards/emptytablecard.png") {
        $(card).children("img").attr("src", $(card).children("img").attr("originalSrc"));
    }
    else{
        $(".cardDetail").hide();
    }
}

function bindTableCardOver(card) {
    if ($(card).children("img").attr("src") == "/images/cards/empty.png") {
        $(card).children("img").attr("src", "/images/cards/emptytablecard.png");
    }
    else {
        //$(".cardDetail").show();
    }
}
//卡牌放大事件
function cardOver(card) {    
    $(card).css("width", "200px");
    $(card).css("height", "310px");
    $(card).css("top", "-250px");
    //$(card).css("left", "-100px");
    $(card).css("z-index", 999999);
}

//卡牌大小位置还原事件
function cardOut(card) {
    $(card).css("width", originalCard.width);
    $(card).css("height", originalCard.height);
    $(card).css("top", "0px");
    $(card).css("left", "0px");
    $(card).css("z-index", $(card).attr("zindex"));
}

//设置牌桌环境
function setDeskCard(players){   
    var currentPlayer = Enumerable.From(players).Where("x=>x.UserCode=='" + getUserCode() + "'").First();
    var currentDeskCards = Enumerable.From(currentPlayer.DeskCards);
    var enemyPlayer = Enumerable.From(players).Where("x=>x.UserCode!='" + getUserCode() + "'").First();
    var enemyDeskCards = Enumerable.From(enemyPlayer.DeskCards);
    //console.log(currentDeskCards);
    $("#myHero").css("background-image", "url('/images/game/texture/hero/" + Enumerable.From(Profession).First(c=>c.Value == currentPlayer.Hero.Profession).Key + ".png')");
    //设置自己牌桌上的牌
    $("#myTableCard li").each(function (idx) {        
        if (currentDeskCards.Any(c=>c != null && c.DeskIndex == $(this).attr("deskcardindex"))) {            
            //如果牌桌上的某个位置有牌，则绑定这个位置
            var card = currentDeskCards.Where(c=>c != null && c.DeskIndex == $(this).attr("deskcardindex")).First();            
            $(this).attr("card",encodeURI(JSON.stringify(card)));
            $(this).children("img").attr("src", card.BackgroudImage);
            $(this).children("img").attr("originalSrc", card.BackgroudImage);
            $(this).children("div").eq(0).addClass("servantDamege").html(card.Damage);
            $(this).children("div").eq(1).addClass("servantLife").html(card.Life);
            //如果这张牌的剩余攻击次数大于0，添加可以攻击的样式
            if (card.RemainAttackTimes > 0) {
                $(this).addClass("ActiveCard");
            }
        }
        else{
            //如果牌桌上的某个位置没有牌，设置默认值
            $(this).attr("card","");
            $(this).children("img").attr("originalSrc", "/images/cards/empty.png");
            $(this).children("img").attr("src", "/images/cards/empty.png");
            $(this).children("div").eq(0).removeClass("servantDamege").html("");
            $(this).children("div").eq(1).removeClass("servantLife").html("");
        }
    });
    
    $("#enemyHero").css("background-image", "url('/images/game/texture/hero/" + Enumerable.From(Profession).First(c=>c.Value == enemyPlayer.Hero.Profession).Key + ".png')");
    //设置对手牌桌上的牌
    $("#otherTableCard li").each(function (idx) {
        if (enemyDeskCards.Any(c=>c != null && c.DeskIndex == $(this).attr("deskcardindex"))) {
            //如果牌桌上的某个位置有牌，则绑定这个位置
            var card = enemyDeskCards.Where(c=>c != null && c.DeskIndex == $(this).attr("deskcardindex")).First();
            //encodeURI(JSON.stringify(value))
            $(this).attr("card",encodeURI(JSON.stringify(card)));
            $(this).children("img").attr("src", card.BackgroudImage);
            $(this).children("div").eq(0).addClass("servantDamege").html(card.Damage);
            $(this).children("div").eq(1).addClass("servantLife").html(card.Life);
        }
        else{
            //如果牌桌上的某个位置没有牌，设置默认值
            $(this).attr("card","");
            $(this).children("img").attr("originalSrc", "/images/cards/empty.png");
            $(this).children("img").attr("src", "/images/cards/empty.png");
            $(this).children("div").eq(0).removeClass("servantDamege").html("");
            $(this).children("div").eq(1).removeClass("servantLife").html("");
        }
    });
}
