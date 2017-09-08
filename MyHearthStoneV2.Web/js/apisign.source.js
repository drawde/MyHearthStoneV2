var apiTime;
var param = "{}";
var intervalName;
var confustionTime;
$(function () {
    if ($("#saveCardGroup")) {
        $("#saveCardGroup").click(saveCardGroup);
    }
});
//同步服务器时间
ajaxGetData("/Option/SyncTime", param, "", "", "", function (data) {
    if (data.code == "100") {
        if (!!intervalName) {
            clearInterval(intervalName);
        }
        apiTime = new Date(data.data.replace("-", "/").replace("-", "/"));
        intervalName = setInterval(function () { apiTime.setSeconds(apiTime.getSeconds() + 1); }, 1000);// console.log(apiTime.Format("yyyy-MM-dd hh:mm:ss"));        
    }
});
$("#apitest").click(function () {
    apiTest();
});

function UnConfusionInt(confutionStr, offset) {
    var numStr = "";
    for (i = 0; i < confutionStr.length; i++) {
        var ascii = confutionStr.charAt(i).charCodeAt();
        var newascii = ascii + 57 - offset.charCodeAt();
        numStr += String.fromCharCode(newascii);
    }
    return numStr;
}

//随机字符串
function randomWord(randomFlag, min, max) {
    var str = "",
        range = min,
        arr = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];

    // 随机产生
    if (randomFlag) {
        range = Math.round(Math.random() * (max - min)) + min;
    }
    for (var i = 0; i < range; i++) {
        pos = Math.round(Math.random() * (arr.length - 1));
        str += arr[pos];
    }
    return str;
}

//获取混淆后的ascii码
function GetConfusionAscii(newAscii, now) {
    var min = 33, max = 126;
    var ascii = newAscii;
    var offset = getConfusionOffset(now);
    if (ascii + offset > max) {
        if (ascii - offset < min) {
            offset = offset % 10;
            ascii += offset;
        }
        else {
            ascii -= offset;
        }
    }
    else if (ascii - offset < min) {
        if (ascii + offset > max) {
            offset = offset % 10;
            ascii -= offset;
        }
        else {
            ascii += offset;
        }
    }
    else {
        ascii += offset;
    }
    ascii = ascii == 60 ? ascii + offset : ascii;
    return ascii;
}

//获取混淆后的步进
function getConfusionOffset(now) {
    var offset = now.getMilliseconds() % 100;
    if (offset == 0 || offset % 10 == 0) {
        var timeArr = now.Format("yyyyMMddhhmm").replace(/(.)(?=[^$])/g, "$1,").split(",").sort().reverse();
        offset = timeArr[0];
    }
    return offset;
}

//签名参数实体
function Sign(sendTime, sign, rndStr) {
    this.sign = sign;
    this.rndStr = rndStr;
    this.sendTime = sendTime;
}

//生成签名
function getSign() {
    var secretcode = "";
    var i = 0;
    confustionTime = "";
    $("[secretcode]").each(function () {
        secretcode += $(this).attr("secretcode").substring(0, 1);
        if (i > 4 && i < 7) {
            var confustionDateTime = $(this).attr("secretcode").substring(1, $(this).attr("secretcode").length);
            var unConfusionTime = addPreZero(UnConfusionInt(confustionDateTime, $(this).attr("secretcode").substring(0, 1)));
            confustionTime = confustionTime + unConfusionTime;
        }
        i = i + 1;
    });
    
    var offsetStr = confustionTime.substring(confustionTime.length - 6);
    var offset = 0;
    for (var x = 0; x < offsetStr.length; x++) {
        offset = offset + parseInt(offsetStr.charAt(x));
    }
    var trueSecretCode = "";
    for (i = 0; i < secretcode.length; i++) {
        var ascii = secretcode.charAt(i).charCodeAt();
        var off = offset;        
        ascii = parseInt(ascii) + parseInt(offset) - parseInt((parseInt(offsetStr) % 10).toString().charCodeAt());
        trueSecretCode = trueSecretCode + String.fromCharCode(ascii);
    }
    //console.log(trueSecretCode);
    var rndCode = randomWord(false, 15);
    return new Sign(apiTime.Format("yyyy-MM-dd hh:mm:ss"), hex_md5(apiTime.Format("yyyy-MM-dd hh:mm:ss") + trueSecretCode + rndCode).toUpperCase(), rndCode);
}

function apiTest() {
    var param = "";
    var sign = getSign();
    ajaxGetData("/Users/TestSign", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
        showMessage(data.msg);
    });
}

function addPreZero(num) {    
    if (num < 10) {
        return '00' + num;
    } else {
        return num;
    }
}

function saveCardGroup() {
    if (cardCount != 30) {
        showMessage("卡牌数量错误!"); return;
    }
    if (!!$("#cbp-spmenu-s2 h3 input").val() == false) {
        showMessage("请输入卡组名称!"); return;
    }
    showLoader();
    var sign = getSign();
    var cards = "";
    $("#cbp-spmenu-s2 [cardCode]").each(function () {
        if (!!cards) {
            cards = cards + ",";
        }
        var count = $(this).html();
        count = count.substr(count.lastIndexOf("X") + 1);
        cards = cards + $(this).attr("cardCode") + " X" + count;
    });
    var param = "{\"GroupName\":\"" + $("#cbp-spmenu-s2 h3 input").val() + "\",\"Cards\":\"" + cards + "\",\"UserCode\":\"" + getUserCode() + "\",\"GroupCode\":\"" + $("#GroupCode").val() + "\",\"Profession\":\"" + window.location.hash.substr(1) + "\"}";
    ajaxGetData("/Users/SaveCardGroup", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
        showMessage(data.msg, function () {
            hideLoader();
            if (data.code == 100) {
                window.location = "/UserCentre/MyCardGroups";
            }
        });
    });
}