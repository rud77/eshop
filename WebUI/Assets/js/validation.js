jQuery(document).ready(function ($) {
    //	Secure hidden fields
    $("input[type=hidden]").attrchange({
        callback: function (event) {
            if (event.attributeName == "value") {
                location.reload();
            }
        }
    });
});