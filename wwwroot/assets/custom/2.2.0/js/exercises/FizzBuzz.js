$("#fizzBuzz").click(
    function fizzBuzz() {
        if ($("#fizz").val() === "" || $("#buzz").val() === "" || Number($("#buzz").val()) < 1 || Number($("#fizz").val()) < 1 || Number($("#buzz").val()) > 100 || Number($("#fizz").val()) > 100) {
            $("#result").text("Entry invalid.  Please make sure you are entering one number, between 1 and 100, in each entry field.");
            return;
        }
        inputNum = []
        inputNum.push(Number($("#fizz").val()), Number($("#buzz").val()));
        inputNum.sort(function (a, b) { return a - b });
        var x = inputNum[0];
        var y = inputNum[1];
        for (var i = 1; i <= 100; i++) {
            if (i % x === 0 && i % y === 0) { //for if the user enters a second number that is a multiple of the first
                $("#result").append("Fizz Buzz FizzBuzz<br>");
            }
            else if (i % (x * y) === 0) {
                $("#result").append("FizzBuzz<br>");
            }
            else if (i % y === 0) {
                $("#result").append("Buzz<br>");
            }
            else if (i % x === 0) {
                $("#result").append("Fizz<br>");
            }
            else {
                $("#result").append(i + "<br>");
            }
        }
    }
)