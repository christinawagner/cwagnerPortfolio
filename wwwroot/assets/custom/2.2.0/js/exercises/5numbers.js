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
            app.numbers.push($("#num1").val(), $("#num2").val(),
                $("#num3").val(), $("#num4").val(), $("#num5").val());
            for (var i = 0; i < app.numbers.length; i++) {
                var test = app.numbers[i];
                if (test === "") {
                    $("#results1").text("Invalid entry." +
                        " Please make sure you are entering one number per entry field.");
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
            $("#results1").text(app.least + " is the lowest number entered!");
            $("#results2").text(app.greatest + " is the greatest number entered!");
            $("#results3").text(app.mean + " is the mean of the numbers entered!");
            $("#results4").text(app.sum + " is the sum of the numbers entered!");
            $("#results5").text(app.product + " is the product of the numbers entered!");
        }
    )
)