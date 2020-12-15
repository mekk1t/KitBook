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
    const current = `Stages[${i}]`;

    let stageContainer = create("div");
    stageContainer.setAttribute("id", `stages_${i}`);
    stageContainer.setAttribute("class", "stage");

    let indexLabel = create("label");
    indexLabel.innerHTML = `Шаг №${i + 1}`;
    indexLabel.setAttribute("class", "control-label");

    let indexInput = create("input");
    indexInput.setAttribute("value", i + 1);
    indexInput.setAttribute("class", "form-control invisible");
    indexInput.setAttribute("type", "number");
    indexInput.setAttribute("name", current.concat(".Index"));

    let descriptionLabel = create("label");
    descriptionLabel.innerHTML = "Описание";
    descriptionLabel.setAttribute("class", "control-label");

    let descriptionTextarea = create("textarea");
    descriptionTextarea.setAttribute("name", current.concat(".Description"));
    descriptionTextarea.setAttribute("class", "form-control lead");

    let imageLabel = create("label");
    imageLabel.innerHTML = "Картинка";
    imageLabel.setAttribute("class", "control-label");
    imageLabel.setAttribute("for", current.concat(".Image"));

    let imageInput = create("input");
    imageInput.setAttribute("type", "file");
    imageInput.setAttribute("class", "form-control-file");
    imageInput.setAttribute("name", current.concat(".Image"));

    let recipeId = create("input");
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

/**
 * A shortcut to "document.createElement()" function.
 * @param {any} tag Tag of the element to be created.
 * @returns {HTMLElement} An HTML element with the provided tag.
 */
function create(tag) {
    return document.createElement(tag);
}