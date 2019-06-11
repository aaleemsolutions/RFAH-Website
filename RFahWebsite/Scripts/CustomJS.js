$(document).ready(function () {
    $(function () {
            load: function (event, ui) {
                $("#search").autocomplete({
                    source: ["c++", "java", "php", "coldfusion",
                        "javascript", "asp", "ruby"],
                    select: function (event, ui) {
                        alert("You selected : " + ui.item.value);
                    }

                });
            }
    });
});