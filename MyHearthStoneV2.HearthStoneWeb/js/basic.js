var PageSize = 10;
var PageIndex = 1;
var TotalCount = 0;
var emailreg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
var mobilereg = /^1(3|4|5|7|8)\d{9}$/;
var signObj;
var apiTime;
var cardBackgroupImage = "http://123.56.130.111:998/images/cards/texture/";
//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//jQuery.support.cors = true;//添加对IE8、9的跨域支持
/**
 *  通过url来获取数据
 * @param method 请求接口的方法
 * @param params 请求参数
 * @param dealfun 对接口数据返回的处理方式
 */
function ajaxGetData(method, params, sign, backfun) {
    methodurl = APIURL + method;
    var data = "{\"param\":" + params;
    if (sign) {
        data += ",\"nonce_str\":\"" + sign.nonce_str + "\",\"sign\":\"" + sign.sign + "\",\"apitime\":\"" + sign.apitime + "\",\"usercode\":\"" + getUserCode() + "\"";
    }
    data += "}";
    //console.log(data);
    $.ajax({
        type: "post",
        url: methodurl,
        dataType: "json",
        data: data,
        //async: false,
        success: function (data) {
            if (data.res == "104") {
                window.parent.location.href = "/UserCentre/signin";
                return;
            }
            backfun(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
}

//拼接signalR接口的参数，如果不需要参数，param="{}"
function appendParam(param, sign) {   
    return param.substring(0, param.length - 1) + ",\"nonce_str\":\"" + sign.nonce_str + "\",\"sign\":\"" + sign.sign + "\",\"apitime\":\"" + sign.apitime + "\"}";
}

function logout() {    
    showLoader();
    $.post("/UserCentre/DoLogOut", {}, function (r) {
        var data = JSON.parse(r);
        if (data.code == "100") {
            showMessage("已退出登录", function () {
                delCookie("User");
                $("#userLabel").fadeOut(1000, function () { $("#visitorLabel").fadeIn(1000) });
                hideLoader();
            });
        }
        else {
            showMessage(data.msg);
            hideLoader();
        }
    });
}
function delCookie(name) {
    $.cookie(name, null, { path: "/" });
}


function getUserCode() {
    if (!!getUser()) {
        return JSON.parse(getUser()).UserCode;
    }
    return "";
}

function getUserName() {
    if (!!getUser()) {
        return JSON.parse(getUser()).UserName;
    }
    return "";
}

function getNickName() {
    if (!!getUser()) {
        return JSON.parse(getUser()).NickName;
    }
    return "";
}

function setUser(User) {
    $.cookie("User", User);
}

function getUser() {
    return $.cookie("User");
}
function showMessage(text, backcall) {
    $.alert({
        title: false,
        animation: 'scaleY',
        closeAnimation: 'scaleX',
        animationSpeed: 500,
        content: text,
        confirmButton: 'okay',
        confirmButtonClass: 'btn-success',
        closeIcon: true,
        onClose: backcall,
    });
}

function showSuccessMessage(msg) {
    notie.alert(1, msg, 2);
}
function showErrorMessage(msg) {
    notie.alert(3, msg, 2);
}
function showConfirmMessage(infoText, callBack) {
    notie.confirm(infoText, 'Yes', 'Cancel', callBack);
}
function showInput(inputText, type, callBack) {
    notie.input(inputText, 'Submit', 'Cancel', type, '', callBack);
}
function showInfoMessage(msg) {
    notie.alert(4, msg, 2);
}
function showConfirm(text, confirmbackcall, cancelbackcall) {
    $.confirm({
        title: "提示",
        animation: 'scaleY',
        closeAnimation: 'scaleX',
        animationSpeed: 500,
        content: text,
        confirmButton: 'okay',
        confirmButtonClass: 'btn-success',
        cancelButton: 'cancel',
        cancelButtonClass: 'btn-danger',
        closeIcon: true,
        confirm: confirmbackcall,
        cancel: cancelbackcall
    });
}
function checknum(value) {
    var Regx = /^[A-Za-z0-9]*$/;
    if (Regx.test(value)) {
        return true;
    }
    else {
        return false;
    }
}
function showLoader() {    
    $('.progress-indicator').show().delay(400);
}
function hideLoader() {
    $('.progress-indicator').hide();
}

// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

figlet.defaults({
    fontPath: '/fonts'
});
figlet("hearthstone", {
    font: "3D-ASCII",
    horizontalLayout: "full",
    verticalLayout: "full"
}, function (err, text) {
    if (err) {
        console.log('something went wrong...');
        console.dir(err);
        return;
    }
    console.log(text);
    console.log("drawde@126.com     https://github.com/drawde/MyHearthStoneV2");
});

function GetRandomNum(Min, Max) {
    var Range = Max - Min;
    var Rand = Math.random();
    return (Min + Math.round(Rand * Range));
}