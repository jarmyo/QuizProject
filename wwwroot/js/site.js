// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function PostAnswer(questionId) {
    var AnswerTextField = document.getElementById("TeamAnser-" + questionId);
    fetch('/Resulter',
        {
            method: "POST",
            body: JSON.stringify({
                Question: questionId,
                Response: AnswerTextField.value
            }),
            headers: {
                RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value,
                'Content-Type': 'application/json',
                Accept: 'application/json',
            }
        }).then(function (result) {
            return result.json();
        }).then(function (r2) {
            console.log(r2);
            //TODO: here, notify if success or fail.
        }
        );
}