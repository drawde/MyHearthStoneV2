$(document).ready(function () {    
    $.ajax({
        // 获取id，challenge，success（是否启用failback）
        url: "/UserCentre/GetCaptcha?t=" + (new Date()).getTime(), // 加随机数防止缓存
        type: "get",
        dataType: "json",
        success: function (data) {
            // 使用initGeetest接口
            // 参数1：配置参数
            // 参数2：回调，回调的第一个参数验证码对象，之后可以使用它做appendTo之类的事件
            initGeetest({
                gt: data.gt,
                challenge: data.challenge,
                product: "embed", // 产品形式，包括：float，embed，popup。注意只对PC版验证码有效
                offline: !data.success, // 表示用户后台检测极验服务器是否宕机，一般不需要关注
                new_captcha: data.new_captcha
                // 更多配置参数请参见：http://www.geetest.com/install/sections/idx-client-sdk.html#config
            }, handlerEmbed);
        }
    });    $('#login_form input').keydown(function (e) {        if (e.keyCode == 13)        {            $('#login_submit').click();        }    });    var check_weixin_login;    $('.btn-wechat').mouseover(function()    {    	if ($(this).find('img').length)    	{    		$(this).addClass('active');    	}    	else    	{    		var _this = $(this);            AWS.loading_mini($('.side-bar .img'), 'show');    		$.post(G_BASE_URL + '/account/ajax/get_weixin_login_qr_url/', function (result)    		{    			if (_this.find('.img img').length)    			{    				_this.find('.img img').attr('src', result.rsm.url);    			}    			else    			{    				_this.find('.img').append('<img class="hide" src="' + result.rsm.url + '" />');                    setTimeout(function()                    {                        _this.find('.img img').show();                        $('#aw-loading-mini-box').detach();                    }, 1000);    			}    		}, 'json');    		$(this).addClass('active');    	}    	check_weixin_login = setInterval(function ()    	{			$.get(G_BASE_URL + '/account/ajax/weixin_login_process/', function (response) {				if (response.errno == 1)				{					window.location.reload();				}			}, 'json');		}, 1500);    });    $('.btn-wechat').mouseout(function()    {    	$(this).removeClass('active');    	clearInterval(check_weixin_login);    });    });var handlerEmbed = function (captchaObj) {
    $("#embed-submit").click(function (e) {
        var validate = captchaObj.getValidate();
        if (!validate) {
            $("#notice")[0].className = "show";
            setTimeout(function () {
                $("#notice")[0].className = "hide";
            }, 2000);
            e.preventDefault();
        }
    });
    // 将验证码加到id为captcha的元素里，同时会有三个input的值：geetest_challenge, geetest_validate, geetest_seccode
    captchaObj.appendTo("#embed-captcha");
    captchaObj.onReady(function () {
        $("#wait")[0].className = "hide";
    });
    // 更多接口参考：http://www.geetest.com/install/sections/idx-client-sdk.html
};

function DoLogin() {
    $("#login_submit").removeClass("btn-primary").addClass("btn-gray").attr("disabled", "disabled");
    if (!!$("#aw-login-user-name").val() == false) {
        showMessage("请填写用户名");
        return false;
    }
    if (checknum($("#aw-login-user-name").val()) == false) {
        showMessage("用户名必须为英文字母或数字");
        return false;
    }

    if (!!$("#aw-login-user-password").val() == false) {
        showMessage("请填写密码");
        return false;
    }

    $.post("/UserCentre/DoLogin", {
        "LoginName": $("#aw-login-user-name").val(), "Password": $("#aw-login-user-password").val(),
        "geetest_challenge": $("input[name='geetest_challenge']").val(), "geetest_seccode": $("input[name='geetest_seccode']").val(),
        "geetest_validate": $("input[name='geetest_validate']").val()
    }, function (r) {
        var data = eval("(" + r + ")");
        if (data.code == "100") {
            showMessage(data.msg, function () { window.location = !!getUrlParam("returnUrl") ? getUrlParam("returnUrl") : "/home/index" });//window.location = "/home/index"
        }
        else {
            showMessage(data.msg);
            $(".geetest_radar_tip_content").hide();
            $(".geetest_reset_tip_content").show();
        }
        $("#login_submit").removeClass("btn-gray").addClass("btn-primary").removeAttr("disabled");
    });
    return false;
}