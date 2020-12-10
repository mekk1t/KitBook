/**
 * Adds a collection of elements to the form to create a new Stage Input.
 * */
function moreStages() {
    let stagesContainer = document.getElementById("stages");
    let stagesCount = stagesContainer.getElementsByClassName("stage").length;

    if (stagesCount == 0) {
        initStagesLabel(stagesContainer);
    }

    appendStageToContainer(stagesCount, stagesContainer);
}

/**
 * Creates a Stages label element and adds it to the provided container.
 * @param {HTMLDivElement} container
 */
function initStagesLabel(container) {
    var label = document.createElement("label");
    label.setAttribute("class", "control-label");
    label.setAttribute("for", "Stages");
    label.innerHTML = "<strong>Шаги по приготовлению</strong>";

    container.appendChild(label);
}

/**
 *
 * @param {number} i Index of the stage to append.
 * @param {HTMLDivElement} container Container to append the stage elements to.
 */
function appendStageToContainer(i, container) {

    let elements = new Array();

    const current = `Stages[${i}]`;

    let stageContainer = document.createElement("div");
    stageContainer.setAttribute("id", `stages_${i}`);
    stageContainer.setAttribute("class", "stage");

    let indexLabel = document.createElement("label");
    indexLabel.innerHTML = `Шаг №${i}`;
    indexLabel.setAttribute("class", "control-label");

    let indexInput = document.createElement("input");
    indexInput.setAttribute("value", i + 1);
    indexInput.setAttribute("class", "form-control invisible");
    indexInput.setAttribute("type", "number");
    indexInput.setAttribute("name", current.concat(".Index"));

    let descriptionLabel = document.createElement("label");
    descriptionLabel.innerHTML = "Описание";
    descriptionLabel.setAttribute("class", "control-label");

    let descriptionTextarea = document.createElement("textarea");
    descriptionTextarea.setAttribute("name", current.concat(".Description"));
    descriptionTextarea.setAttribute("class", "form-control lead");

    let imageLabel = document.createElement("label");
    imageLabel.innerHTML = "Картинка";
    imageLabel.setAttribute("class", "control-label");
    imageLabel.setAttribute("for", current.concat(".Image"));

    let imageInput = document.createElement("input");
    imageInput.setAttribute("type", "file");
    imageInput.setAttribute("class", "form-control-file");
    imageInput.setAttribute("name", current.concat(".Image"));

    let recipeId = document.createElement("input");
    recipeId.setAttribute("class", "invisible");
    recipeId.setAttribute("name", current.concat(".RecipeId"));
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