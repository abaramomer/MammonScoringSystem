function getAnswers(form) {
    var answers = [];
    getBoolAnswers(form, answers);
    getVariableAnswers(form, answers);

    return answers;
}


function getBoolAnswers(form, answers) {
    form.find(".bool-question").each(function() {
        var value = $(this).find("input:checked").val();
        console.log(value);
        answers.push({ QuestionId: $(this).attr("id"), Answer: value });
    });
}

function getVariableAnswers(form, answers) {
    form.find(".variable-question").each(function () {
        var value = $(this).find("option:selected").val();
        console.log(value);
        answers.push({ QuestionId: $(this).attr("id"), Answer: value });
    });
}