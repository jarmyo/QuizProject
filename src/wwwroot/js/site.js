function PostAnswer(questionId) {
    var AnswerTextField = document.getElementById("TeamAnser-" + questionId);
    var token = document.getElementsByName("__RequestVerificationToken")[0];
    fetch('/Resulter', {
        method: "POST",
        body: JSON.stringify({
            Question: questionId,
            Response: AnswerTextField.value
        }),
        headers: {
            RequestVerificationToken: token.value,
            'Content-Type': 'application/json',
            Accept: 'application/json',
        }
    }).then(function (result) {
        return result.json();
    }).then(function (r2) {
        console.log(r2);
    });
}
//# sourceMappingURL=site.js.map