var url = "/UserCentre/DoRegister";
var handlerEmbed = function (captchaObj) {
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

$(function () {    
    verify_register_form('#register_form');
    reloadCapcha();
});

function reloadCapcha() {
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
    });
}
function postRegister() {    
    if (!!$("#UserName").val() == false) {
        showMessage("请填写用户名");
        return false;
    }    
    if (checknum($("#UserName").val()) == false) {
        showMessage("用户名必须为英文字母或数字");
        return false;
    }
    //if (!emailreg.test($("#Email").val())) {
    //    showMessage("邮箱格式错误");
    //    return false;
    //}
    //if (!mobilereg.test($("#Mobile").val())) {
    //    showMessage("手机号格式错误");
    //    return false;
    //}
    if (!!$("#Password").val() == false) {
        showMessage("请填写密码");
        return false;
    }
    if (!!$("#NickName").val() == false) {
        showMessage("请填写昵称");
        return false;
    }
    if (!!$("#InvitationCode").val() == false) {
        showMessage("请填写邀请码");
        return false;
    }
    showLoader();
    //$("#btnReg").removeClass("btn-blue").addClass("btn-gray").attr("disabled", "disabled");
    $.post(url, {
        "UserName": $("#UserName").val(), "Password": $("#Password").val(), "NickName": $("#NickName").val(),
        "Mobile": $("#Mobile").val(), "Email": $("#Email").val(), "InvitationCode": $("#InvitationCode").val(),
        "geetest_challenge": $("input[name='geetest_challenge']").val(), "geetest_seccode": $("input[name='geetest_seccode']").val(), 
        "geetest_validate": $("input[name='geetest_validate']").val()
    }, function (r) {
        var data = JSON.parse(r);
        if (data.code == "100") {
            //hideLoader();
            showMessage(data.msg, function () { hideLoader(); window.location = "/home/index" });
        }
        else {
            hideLoader();
            showMessage(data.msg);
            $(".geetest_radar_tip_content").hide();
            $(".geetest_reset_tip_content").show();
        }
        //$("#btnReg").removeClass("btn-gray").addClass("btn-blue").removeAttr("disabled");
    });
    return false;
}

/* 注册页面验证 */
function verify_register_form(element) {
    $(element).find('[type=text], [type=password]').on({
        focus: function () {
            if (typeof $(this).attr('tips') != 'undefined' && $(this).attr('tips') != '') {
                $(this).parent().append('<span class="aw-reg-tips">' + $(this).attr('tips') + '</span>');
            }
        },
        blur: function () {
            if ($(this).attr('tips') != '') {
                switch ($(this).attr('id')) {
                    case 'UserName':
                        var _this = $(this);
                        $(this).parent().find('.aw-reg-tips').detach();
                        if ($(this).val().length >= 0 && $(this).val().length < 2) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        if ($(this).val().length > 17) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        else {
                            var param = "{\"UserName\":\"" + $("#UserName").val() + "\"}";
                            ajaxGetData("/Users/ValidateUserName", param,"","","", function (data) {                                
                                if (data.code != "100") {                                    
                                    _this.parent().find('.aw-reg-tips').detach();
                                    _this.parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + data.msg + '</span>');
                                }
                                else {
                                    _this.parent().find('.aw-reg-tips').detach();
                                    _this.parent().append('<span class="aw-reg-tips aw-reg-right"><i class="aw-icon i-followed"></i></span>');
                                }
                            });                            
                        }
                        return;
                    case 'NickName':
                        var _this = $(this);
                        $(this).parent().find('.aw-reg-tips').detach();
                        if ($(this).val().length >= 0 && $(this).val().length < 2) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        if ($(this).val().length > 10) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }                        
                        return;
                    case 'InvitationCode':
                        var _this = $(this);
                        $(this).parent().find('.aw-reg-tips').detach();
                        if ($(this).val().length < 1 || $(this).val().length > 50) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        return;
                    case 'Email':
                        $(this).parent().find('.aw-reg-tips').detach();
                        
                        if (!emailreg.test($(this).val())) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        else {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-right"><i class="aw-icon i-followed"></i></span>');
                        }
                        return;
                    case 'Mobile':
                        $(this).parent().find('.aw-reg-tips').detach();
                        
                        if (!mobilereg.test($(this).val())) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        else {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-right"><i class="aw-icon i-followed"></i></span>');
                        }
                        return;
                    case 'Password':
                        $(this).parent().find('.aw-reg-tips').detach();
                        if ($(this).val().length >= 0 && $(this).val().length < 6) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        if ($(this).val().length > 17) {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-err"><i class="aw-icon i-err"></i>' + $(this).attr('errortips') + '</span>');
                            return;
                        }
                        else {
                            $(this).parent().find('.aw-reg-tips').detach();
                            $(this).parent().append('<span class="aw-reg-tips aw-reg-right"><i class="aw-icon i-followed"></i></span>');
                        }
                        return;

                }
            }

        }
    });
}