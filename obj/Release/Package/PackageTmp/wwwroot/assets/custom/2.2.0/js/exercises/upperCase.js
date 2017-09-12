$(document).ready(
    $("#goBtn").click(
        function () {
            var phrase = $("#phrase").val().toLowerCase();
            var result = "";
            for (var i = 0; i < phrase.length; i++) {
                if (i == 0 || (phrase[i - 1]) == ' ') {
                    result += phrase[i].toUpperCase();
                }
                else {
                    result += phrase[i];
                }
            }
            $("#result").text(result);
        })
)