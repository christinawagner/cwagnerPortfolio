$(document).ready(
    $("#abcMe").click(
        function () {
            var word = $("#word").val();
            var remove = /[\W_]/g;
            var newWord = word.replace(remove, "");
            newWord = newWord.split("").sort(Intl.Collator().compare).join("");
            $("#result").text(newWord);
        }
    )
)