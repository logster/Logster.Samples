// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in Ripple or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    // add the logster api key header
    $.ajaxSetup({ headers: { "ApiKey": "your-api-key" } });

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );

        var message = {
            "Message": "app loaded",
            "Severity": 2,
            "Category": "Widget Designer",
            "Application": "Logster.Samples.Cordova",
            "User": "john-doe"
        };
        $.post("https://api.logster.io/api/Log", message);

        // TODO: Cordova has been loaded. Perform any initialization that requires Cordova here.
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.

        var message = {
            "Message": "app paused",
            "Severity": 2,
            "Category": "Widget Designer",
            "Application": "Logster.Samples.Cordova",
            "User": "john-doe"
        };
        $.post("https://api.logster.io/api/Log", message);
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.

        var message = {
            "Message": "app resumed",
            "Severity": 2,
            "Category": "Widget Designer",
            "Application": "Logster.Samples.Cordova",
            "User": "john-doe"
        };
        $.post("https://api.logster.io/api/Log", message);
    };
} )();