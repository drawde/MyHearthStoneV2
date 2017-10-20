var param = "{}";
var intervalName;
var confustionTime;
//同步服务器时间
ajaxGetData("/Option/SyncTime", param, null, function (data) {
    if (data.code == "100") {
        console.log("hided");
        hideLoader();
        if (!!intervalName) {
            clearInterval(intervalName);
        }
        apiTime = new Date(data.data.replace("-", "/").replace("-", "/"));
        intervalName = setInterval(function () { apiTime.setSeconds(apiTime.getSeconds() + 1); }, 1000);// console.log(apiTime.Format("yyyy-MM-dd hh:mm:ss"));  
        if (apiTime) {
            signObj = getSign();
        }
        setInterval(function () { signObj = getSign(); }, 10000);
    }
});

function UnConfusionInt(confutionStr, offset) {
    var numStr = "";
    for (var idx = 0; idx < confutionStr.length; idx++) {
        var ascii = confutionStr.charAt(idx).charCodeAt();
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
    for (var idx = 0; idx < range; idx++) {
        var pos = Math.round(Math.random() * (arr.length - 1));
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
function Sign(apitime, sign, nonce_str) {
    this.sign = sign;
    this.nonce_str = nonce_str;
    this.apitime = apitime;
}

//生成签名
function getSign() {
    var secretcode = "";
    var idx = 0;
    confustionTime = "";
    $("[secretcode]").each(function () {
        secretcode += $(this).attr("secretcode").substring(0, 1);
        if (idx > 4 && idx < 7) {
            var confustionDateTime = $(this).attr("secretcode").substring(1, $(this).attr("secretcode").length);
            var unConfusionTime = addPreZero(UnConfusionInt(confustionDateTime, $(this).attr("secretcode").substring(0, 1)));
            confustionTime = confustionTime + unConfusionTime;
        }
        idx = idx + 1;
    });

    var offsetStr = confustionTime.substring(confustionTime.length - 6);
    var offset = 0;
    for (var x = 0; x < offsetStr.length; x++) {
        offset = offset + parseInt(offsetStr.charAt(x));
    }
    var trueSecretCode = "";
    for (idx = 0; idx < secretcode.length; idx++) {
        var ascii = secretcode.charAt(idx).charCodeAt();
        var off = offset;
        ascii = parseInt(ascii) + parseInt(offset) - parseInt((parseInt(offsetStr) % 10).toString().charCodeAt());
        trueSecretCode = trueSecretCode + String.fromCharCode(ascii);
    }
    //console.log(trueSecretCode);
    var rndCode = randomWord(false, 15);
    var at = apiTime.Format("yyyy-MM-dd hh:mm:ss");
    return new Sign(at, hex_md5(at + trueSecretCode + rndCode).toUpperCase(), rndCode);
}

function addPreZero(num) {
    if (num < 10) {
        return '00' + num;
    } else {
        return num;
    }
}