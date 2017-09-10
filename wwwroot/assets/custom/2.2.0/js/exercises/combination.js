$(document).ready(
    $("#pair").click(
        function () {
            var word = $("#word").val();
            var remove = /[\W_]/g;
            var newWord = word.replace(remove, "");
            newWord = newWord.split('');
            var output = [];
            var cmb;
            cmb = Combinatorics.power(newWord);
            cmb.forEach(function (a) { output.push(a.join('')) });
            $("#result").text(output.filter(function (b) { return b !== "" }).join(', '))
        }
    )
)