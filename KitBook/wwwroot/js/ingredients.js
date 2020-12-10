const amount = "Amount";
const ml = "Ml";
const g = "G";

function moreIngredients() {
    let container = document.getElementById("ingredients");
    let childrenLength = container.childElementCount;

    appendIngredientToContainer(childrenLength, container);
}

function appendIngredientToContainer(i, container) {
    var currentIngredient = `Ingredients[${i}]`;

    let amountClassName = amount.concat(i);
    let mlClassName = ml.concat(i);
    let gClassName = g.concat(i);

    let ingredientContainer = document.createElement("div");
    ingredientContainer.className = "ingredient";

    let nameLabel = document.createElement("label");
    nameLabel.className = "control-label";
    nameLabel.innerHTML = "Название";

    let _select = document.createElement("select");
    _select.className = "form-control";
    _select.name = currentIngredient + ".IngredientId";
    _select.id = `ingredientsSelect_${i}`;
    $(_select).load(window.location.origin.concat("/Ingredient/IngredientsSelectList"));

    let recipeIdInput = document.createElement("input");
    recipeIdInput.setAttribute("class", "invisible");
    recipeIdInput.setAttribute("name", currentIngredient.concat(".RecipeId"));
    recipeIdInput.setAttribute("value", $("#Id").val())

    ingredientContainer.append(nameLabel);
    ingredientContainer.append(_select);

    let elements = createMetricsElements(amount, i, "Шт.", currentIngredient, ingredientContainer);
    appendElements(elements, ingredientContainer);

    elements = createMetricsElements(g, i, "Грамм", currentIngredient, ingredientContainer);
    appendElements(elements, ingredientContainer);

    elements = createMetricsElements(ml, i, "Мл", currentIngredient, ingredientContainer);
    appendElements(elements, ingredientContainer);

    ingredientContainer.append(createMetricButton(amountClassName, "Шт"));
    ingredientContainer.append(createMetricButton(mlClassName, "Мл"));
    ingredientContainer.append(createMetricButton(gClassName, "Грамм"));
    ingredientContainer.append(recipeIdInput);

    container.append(ingredientContainer);
}

function appendElements(elements, container) {
    for (let j = 0; j < elements.length; j++) {
        container.append(elements[j]);
    }
}

/**
 * Shows the metric's label and input.
 * Hides other metrics' buttons.
 * @param {string} metricClassName
 */
function activateMetric(metricClassName) {
    $(".metric-radio-button").hide();
    var elements = document.getElementsByClassName(metricClassName);
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.display = "block";
    }
}

/**
 * Creates a button specific to the provided metric.
 * @param {string} metricClassName The name of the metric class.
 * @param {string} buttonText The text to display on the button.
 */
function createMetricButton(metricClassName, buttonText) {
    var button = document.createElement("button");

    button.innerText = buttonText;
    button.setAttribute("class", "btn btn-outline-primary metric-radio-button");
    button.setAttribute("type", "button");
    button.addEventListener("click", function () { activateMetric(metricClassName) }, false);

    return button;
}

/**
 * Creates two elements: a label and an input with the provided name as a class attribute.
 * @param {string} name Name of the Ingredient view model property.
 * @param {number} index Index of the current ingredient.
 * @param {string} labelHtml HTML to be displayed as a label.
 * @returns Array of two elements: label and input.
 */
function createMetricsElements(name, index, labelHtml) {
    let current = `Ingredients[${index}]`;
    let label = document.createElement("label");
    label.setAttribute("class", `control-label ${name.concat(index)}`);
    label.setAttribute("id", `${name}Label${index}`);
    label.innerHTML = labelHtml;
    label.style.display = "none";

    let input = document.createElement("input");
    input.setAttribute("class", `form-control ${name.concat(index)}`);
    input.setAttribute("type", "number");
    input.setAttribute("id", `${name}Input${index}`);
    input.setAttribute("name", `${current}.${name}`);
    input.style.display = "none";

    let elements = [label, input];

    return elements;
}