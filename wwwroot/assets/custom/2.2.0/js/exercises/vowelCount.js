$(document).ready(
    $("#eieio").click(
        function () {
            var phrase = $("#phrase").val().toLowerCase();
            var result = "";
            var count = 0
            for (var i = 0; i < phrase.length; i++)
                if (phrase[i] == "a" || phrase[i] == "e" || phrase [i] == "i" || phrase[i] == "o" || phrase[i] == "u") {
                    result += (phrase[i] + ", ");
                    count++;
                };
            $("#result").text(result + " = " + count + " vowels in your phrase.");
        }
    )
)