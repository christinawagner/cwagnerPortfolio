//Palindrome
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

//FizzBuzz
$(document).ready(
    $("#fizzBuzz").click(
        function fizzBuzz() {
            if ($("#fizz").val() === "" || $("#buzz").val() === "" || Number($("#buzz").val()) < 1 || Number($("#fizz").val()) < 1 || Number($("#buzz").val()) > 100 || Number($("#fizz").val()) > 100) {
                $("#resultFb").text("Entry invalid.  Please make sure you are entering one number, between 1 and 100, in each entry field.");
                return;
            }
            inputNum = []
            inputNum.push(Number($("#fizz").val()), Number($("#buzz").val()));
            inputNum.sort(function (a, b) { return a - b });
            var x = inputNum[0];
            var y = inputNum[1];
            for (var i = 1; i <= 100; i++) {
                if (i % x === 0 && i % y === 0) { //for if the user enters a second number that is a multiple of the first
                    $("#resultFb").append("Fizz Buzz FizzBuzz<br>");                   
                }
                else if (i % (x * y) === 0) {
                    $("#resultFb").append("FizzBuzz<br>");
                }
                else if (i % y === 0) {
                    $("#resultFb").append("Buzz<br>");
                }
                else if (i % x === 0) {
                    $("#resultFb").append("Fizz<br>");
                }
                else {
                    $("#resultFb").append(i + "<br>");
                }
            }
        }
    )
)

//Numbers
$(document).ready(
    app = {
        least: "",
        greatest: "",
        mean: "",
        sum: 0,
        product: 1,
        numbers: [],
    },
    $("#sorting").click(
        function () {
            app.numbers.push($("#num1").val(), $("#num2").val(), $("#num3").val(), $("#num4").val(), $("#num5").val());
            for (var i = 0; i < app.numbers.length; i++) {
                var test = app.numbers[i];
                if (test === "") {
                    $("#results1").text("Invalid entry. Please make sure you are entering one number per entry field.");
                    return;
                }
            }
            app.numbers.sort(function (a, b) { return a - b });
            app.least = app.numbers[0];
            app.greatest = app.numbers[4];
            for (var j = 0; j < app.numbers.length; j++) {
                app.sum += Number(app.numbers[j]);
                app.product *= Number(app.numbers[j]);
            }
            app.mean = Number(app.sum) / app.numbers.length;
            $("#results2").text(app.greatest + " is the greatest number entered!");
            $("#results1").text(app.least + " is the lowest number entered!");
            $("#results3").text(app.mean + " is the mean of the numbers entered!");
            $("#results4").text(app.sum + " is the sum of the numbers entered!");
            $("#results5").text(app.product + " is the product of the numbers entered!");
        }
    )
)

//Factorial
$(document).ready(
    $("#factorial").click(
        function l() {
            if ($("#num").val() === "") {
                $("#resultFac").text("Entry invalid.  Please make sure you are entering one number in each entry field.");
                return;
            }
            var answer = 1;
            for (i = $("#num").val(); i > 0; i--) {
                answer *= Number(i);
            }
            $("#resultFac").text("Your answer is: " + answer);
        }
    )
)

//Alphabetical Order
$(document).ready(
    $("#abcMe").click(
        function () {
            var word = $("#wordAbc").val();
            var remove = /[\W_]/g;
            var newWord = word.replace(remove, "");
            newWord = newWord.split("").sort(Intl.Collator().compare).join("");
            $("#resultAbc").text(newWord);
        }
    )
)

//Combinations
$(document).ready(
    $("#pair").click(
        function () {
            var word = $("#wordCom").val();
            var remove = /[\W_]/g;
            var newWord = word.replace(remove, "");
            newWord = newWord.split('');
            var output = [];
            var cmb;
            cmb = Combinatorics.power(newWord);
            cmb.forEach(function (a) { output.push(a.join('')) });
            $("#resultCom").text(output.filter(function (b) { return b !== "" }).join(', '))
        }
    )
)

//Prime Number
$(document).ready(
    $("#prime").click(
        function () {
            if ($("#number").val() === "") {
                $("#resultPrime").text("Invalid entry.  Please make sure to enter a number.");
                return;
            }
            var number = Number($("#number").val());
            if (number == 0 || number == 1 || number == 2) {
                $("#resultPrime").text(number + " is not prime");
                return;
            }
            for (var i = 2; i <= Math.sqrt(number); i++) {
                if (number % i == 0) {
                    $("#resultPrime").text(number + " is not prime. It is divisible by " + i);
                    return;
                }
            }
            $("#resultPrime").text(number + " is prime!")
        }
    )
)

//Upper Case
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
            $("#resultUpper").text(result);
        })
)

//Vowel Count
$(document).ready(
    $("#eieio").click(
        function () {
            var phrase = $("#phraseVowel").val().toLowerCase();
            var result = "";
            var count = 0
            for (var i = 0; i < phrase.length; i++)
                if (phrase[i] == "a" || phrase[i] == "e" || phrase[i] == "i" || phrase[i] == "o" || phrase[i] == "u") {
                    result += (phrase[i] + ", ");
                    count++;
                };
            $("#resultVowel").text(result + " = " + count + " vowels in your phrase.");
        }
    )
)