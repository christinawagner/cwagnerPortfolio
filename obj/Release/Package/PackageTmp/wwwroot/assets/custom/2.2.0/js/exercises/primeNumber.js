$(document).ready(
    $("#prime").click(
        function () {
            if ($("#number").val() === "") {
                $("#result").text("Invalid entry.  Please make sure to enter a number.");
                return;
            }
            var number = Number($("#number").val());
            if (number == 0 || number == 1 || number == 2) {
                $("#result").text(number + " is not prime");
                return;
            }
            for (var i = 2; i <= Math.sqrt(number); i++) {
                if (number % i == 0) {
                    $("#result").text(number + " is not prime. It is divisible by " + i);
                    return;
                }
            }
            $("#result").text(number + " is prime!")
        }
    )
)