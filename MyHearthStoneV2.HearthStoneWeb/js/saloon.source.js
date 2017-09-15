$(function () {
    getSaloons();
    $("#createsaloonFrom").submit(function () {
        if (!!$("input[name='name']").val() == false) {
            showMessage("请输入房间名");
            return false;
        }
        showLoader();
        var sign = getSign();
        var param = "{\"Name\":\"" + $("input[name='name']").val() + "\",\"Password\":\"" + $("input[name='password']").val() + "\",\"UserCode\":\"" + getUserCode() + "\"}";
        ajaxGetData("/Saloon/CreateOrUpdate", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
            showMessage(data.msg, function () {
                hideLoader();
                if (data.code == 100) {
                    window.location = "/game/saloon";
                }
            });
        });
        
        return false;
    });    
});
var PageNo = 1;
function getSaloons() {
    showLoader();
    var sign = getSign();
    var param = "{\"PageSize\":\"10\",\"PageNo\":\"" + PageNo + "\"}";
    ajaxGetData("/Saloon/GetSaloons", param, sign.rndStr, sign.sign, sign.sendTime, function (data) {
        hideLoader();
        if (data.code == 100) {
            $(".text-list").append("<div class=\"item\">"+
                        "<div class=\"description\">"+
                            "<h2><a href=\"/recipes/url-content-topic-extraction-microservice\">URL Topic Extraction</a></h2>"+
                            "<p>Extract the content from a given web page and return topics using LDA.</p>"+
                            "<div class=\"meta\">"+
                                "<ul class=\"tag-list\">"+
                                    "<li><a href=\"/recipes/category/etl\" class=\"btn btn-sm\">etl</a></li>"+
                                    "<li><a href=\"/recipes/category/natural-language-processing\" class=\"btn btn-sm\">natural language-processing</a></li>"+
                                "</ul>"+
                            "</div>"+
                        "</div>"+
                        "<div class=\"action\">"+
                            "<a href=\"/recipes/url-content-topic-extraction-microservice\" class=\"btn\">Read More</a>"+
                        "</div>"+
                    "</div>");
        }
    });
}