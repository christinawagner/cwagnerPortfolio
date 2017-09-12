//$(document).ready(
//    $("#palindrome").click(
//        function () {
//            if ($("#word").val() === $("#word").val().split('').reverse().join(''))
//                $("#result").text($("#word").val() + " spelled backwords is " + $("#word").val() + " ! That makes it a palindrome!  Yay!");
//            else
//                $("#result").text("That is not a palindrome.  Better luck next time.");
//        }
//    )
//)
$(document).ready(
    $("#palindrome").click(
        function () {
            var word = $("#word").val().toLowerCase();
            var remove = /[\W_]/g;
            word = word.replace(remove, "");
            var splitWord = word.split('');
            var newWord = '';
            for (var i = splitWord.length - 1; i >= 0; i--) {
                newWord += splitWord[i];
            }
            if (word === newWord) {
                $("#result").text(word + " spelled backwords is " + newWord + "! That makes it a palindrome!  Yay!");
            }
            else {
                $("#result").text(word + " spelled backwords is " + newWord + ". That is not a palindrome.  Better luck next time.");
            }
        }
    )
)