/// <reference path="knockout-2.2.1.js" />
/// <reference path="jquery-2.0.2.js" />
var AppEngineviewModel = function () {

    $this = this;


    url: "/(.*\.(appcache|manifest))";
    static_files: 1;
    mime_type: "text/cache-manifest";
    upload: "(.*\.(appcache|manifest))";
    expiration: "0s";

}


window.applicationCache.addEventListener('updateready', function (e) {
    if (window.applicationCache.status == window.applicationCache.UPDATEREADY) {
        window.applicationCache.swapCache();
        if (confirm('A new version of this site is available. Load it?')) {
            window.location.reload();
        }
    }
}, false);

