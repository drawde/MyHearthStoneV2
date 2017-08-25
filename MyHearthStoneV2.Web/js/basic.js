var PageSize = 10;
var PageIndex = 1;
var TotalCount = 0;
var emailreg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
var mobilereg = /^1(3|4|5|7|8)\d{9}$/;
//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
//jQuery.support.cors = true;//添加对IE8、9的跨域支持
/**
 *  通过url来获取数据
 * @param method 请求接口的方法
 * @param params 请求参数
 * @param dealfun 对接口数据返回的处理方式
 */
function ajaxGetData(method, params, backfun) {
    methodurl = APIURL + method;
    var token = getToken();
    var data = "{\"token\":\"" + token + "\",\"param\":" + params + "}";
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
};

function getToken() {
    if (!!getCookie("token")) {
        return getCookie("token");
    }
    return "";
}
//登录时将token的值保存到session里面
function setToken(value) {
    setCookie("token", value);
}
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}
function setCookie(name, value) {
    var Days = 30;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}


function getUserCode() {
    return eval('(' + getUser() + ')').UserCode;
}

function getUserName() {
    return eval('(' + getUser() + ')').UserName;
}

function getNickName() {
    return eval('(' + getUser() + ')').NickName;
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
        confirm: backcall,
    });
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