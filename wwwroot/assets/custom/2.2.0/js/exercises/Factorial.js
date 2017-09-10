$(document).ready(
    $("#factorial").click(
        function l() {
            if ($("#num").val() === "") {
                $("#result").text("Entry invalid.  Please make sure you are entering one number in each entry field.");
                return;
            }
            var answer = 1;
            for (i = $("#num").val(); i > 0; i--) {
                answer *= Number(i);
            }
            $("#result").text("Your answer is: " + answer);
        }
    )
)