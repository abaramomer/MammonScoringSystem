function getCoefficients(form) {
    var coefficients = [];
    getBoolCoefficients(form, coefficients);
    getVariableCoefficients(form, coefficients);

    return coefficients;
}


function getBoolCoefficients(form, coefficients) {
    form.find(".bool-question").each(function () {
        var value = $(this).find("input").val();
        console.log(value);
        coefficients.push({ QuestionId: $(this).attr("id"), AnswerId: null, Coefficient: value });
    });
}

function getVariableCoefficients(form, coefficients) {
    form.find(".variable-question").each(function () {
        var questionId = $(this).attr("id");
        $(this).find("input").each(function () {
            var value = $(this).val();
            console.log(value);
            coefficients.push({ QuestionId: questionId, AnswerId: $(this).attr("id"), Coefficient: value });
        });
    });
}