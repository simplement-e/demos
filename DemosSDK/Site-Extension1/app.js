(function () {
    var domain = getParameterByName("$from");
    if (domain == "") domain = "http://app.simplement-e.com/";
    window.addEventListener("resize", function (e) {
        setTimeout(signalSize, 150);
    });
    document.addEventListener("DOMContentLoaded", function (e) {
        setTimeout(signalSize, 150);
    });
    window.addEventListener("load", function (e) {
        setTimeout(signalSize, 150);
    });

    function signalSize() {
        if (parent != null) {
            var height = document.body.scrollHeight;
            if(document.documentElement!=null && document.documentElement!="undefined")
                height = document.documentElement.scrollHeight;
            //if (window.innerHeight != null && window.innerHeight!= "undefined")
            //    height = window.innerHeight;
            parent.postMessage("_e_sizing_;" + height, domain);
        }
    }

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]").replace("$", "\\$");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.search);
        if (results == null)
            return "";
        else
            return decodeURIComponent(results[1].replace(/\+/g, " "));
    }
})();