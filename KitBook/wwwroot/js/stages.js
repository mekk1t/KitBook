

function initLabel(stagesContainer) {
    var label = document.createElement("label");
    label.setAttribute("class", "control-label");
    label.setAttribute("for", "Stages");
    label.innerHTML = "Шаги по приготовлению";

    _class(label, "control-label");
    $(stagesContainer).append(label);
}

function moreStages() {
    let stagesContainer = $("#stages");
    if (stagesContainer.children().length == 0) {
        initLabel(stagesContainer);
    }
    appendStageToContainer(stagesContainer.children(".stagesDiv").length, stagesContainer);
}

function appendStageToContainer(i, container) {

    var currentStage = "Stages".concat("[", i, "]");

    var stageContainer = document.createElement("div");

    stageContainer.setAttribute("id", "stage_".concat(i));
    stageContainer.setAttribute("class", "count");

    var indexLabel = document.createElement("label");
    indexLabel.innerHTML = indexLabel.innerHTML.concat("Шаг № ", i + 1);
    indexLabel.setAttribute("class", "control-label");
    indexLabel.setAttribute("for", currentStage.concat("__Index"));

    var indexInput = document.createElement("input");
    indexInput.setAttribute("value", i + 1);
    indexInput.setAttribute("class", "form-control");
    indexInput.setAttribute("class", "invisible");
    indexInput.setAttribute("type", "number");
    indexInput.setAttribute("name", currentStage.concat(".Index"));

    var descriptionLabel = document.createElement("label");
    descriptionLabel.innerHTML = "Описание";
    descriptionLabel.setAttribute("class", "control-label");

    var descriptionTextarea = document.createElement("textarea");
    descriptionTextarea.setAttribute("name", currentStage.concat(".Description"));
    descriptionTextarea.setAttribute("class", "form-control");
    autosize(descriptionTextarea);

    var imageLabel = document.createElement("label");
    imageLabel.innerHTML = "Картинка";
    imageLabel.setAttribute("class", "control-label");
    imageLabel.setAttribute("for", currentStage.concat(".Image"));

    var imageInput = document.createElement("input");
    imageInput.setAttribute("type", "file");
    imageInput.setAttribute("class", "form-control-file");
    imageInput.setAttribute("name", currentStage.concat(".Image"));

    var recipeId = document.createElement("input");
    recipeId.setAttribute("class", "invisible");
    recipeId.setAttribute("name", currentStage.concat(".RecipeId"));
    recipeId.setAttribute("value", $("#Id").val())


    stageContainer.append(indexLabel);
    stageContainer.append(indexInput);
    stageContainer.append(document.createElement("br"));
    stageContainer.append(descriptionLabel);
    stageContainer.append(descriptionTextarea);
    stageContainer.append(imageLabel);
    stageContainer.append(imageInput);
    stageContainer.append(recipeId);
    stageContainer.append(document.createElement("br"));

    container.append(stageContainer);
}