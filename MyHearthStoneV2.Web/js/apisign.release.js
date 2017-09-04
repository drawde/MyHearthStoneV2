(function () {
    var re = /x/;
    console.log(re);

    re.toString = function () {
        while (1) {
        }
        return '';
    };
})();