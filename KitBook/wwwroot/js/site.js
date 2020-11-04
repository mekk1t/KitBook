// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function appendStagesToForm() {
    var stagesNumber = $("#stagesCount").val();
    var stagesContainer = document.getElementById("stages");

    for (var i = 0; i < stagesNumber; i++) {

        var currentStage = "Stages".concat("[", i, "]");

        var indexLabel = document.createElement("label");
        indexLabel.innerHTML = indexLabel.innerHTML.concat("№", i + 1);
        var indexInput = document.createElement("input");
        indexInput.setAttribute("readonly", "readonly");
        indexInput.setAttribute("value", i);
        var indexName = currentStage.concat(".Index");
        indexInput.setAttribute("name", indexName);

        var descriptionLabel = document.createElement("label");
        descriptionLabel.innerHTML = "Описание шага";

        var descriptionTextarea = document.createElement("textarea");
        descriptionTextarea.setAttribute("name", currentStage.concat(".Description"));

        stagesContainer.appendChild(indexLabel);
        stagesContainer.appendChild(indexInput);
        stagesContainer.appendChild(descriptionLabel);
        stagesContainer.appendChild(descriptionTextarea);
    }
}