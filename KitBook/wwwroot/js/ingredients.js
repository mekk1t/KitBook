function moreIngredients() {
    let container = document.getElementById("ingredients");
    let childrenLength = container.childElementCount;

    appendIngredientToContainer(childrenLength, container);
}

function appendIngredientToContainer(i, container) {
    const amount = "Amount";
    const ml = "Ml";
    const g = "G";

    var currentIngredient = `Ingredients[${i}]`;

    var ingredientContainer = document.createElement("div");
    ingredientContainer.className = "ingredient";

    let nameLabel = document.createElement("label");
    nameLabel.className = "control-label";
    nameLabel.innerHTML = "Название";

    var _select = document.createElement("select");
    _select.className = "form-control";
    _select.name = currentIngredient + ".IngredientId";
    _select.id = `ingredientsSelect_${i}`;
    $(_select).load(window.location.origin.concat("/Ingredient/IngredientsSelectList"));

    var recipeIdInput = document.createElement("input");
    recipeIdInput.setAttribute("class", "invisible");
    recipeIdInput.setAttribute("name", currentIngredient.concat(".RecipeId"));
    recipeIdInput.setAttribute("value", $("#Id").val())

    ingredientContainer.append(nameLabel);
    ingredientContainer.append(_select);

    var elements = createMetricsElements(amount, i, "Шт.", currentIngredient, ingredientContainer);

    ingredientContainer.append(elements[0]);
    ingredientContainer.append(elements[1]);

    elements = createMetricsElements(g, i, "Грамм", currentIngredient, ingredientContainer);

    ingredientContainer.append(elements[0]);
    ingredientContainer.append(elements[1]);

    elements = createMetricsElements(ml, i, "Мл", currentIngredient, ingredientContainer);
    ingredientContainer.append(elements[0]);
    ingredientContainer.append(elements[1]);

    ingredientContainer.append(createMetricButton(amount, "Шт"));
    ingredientContainer.append(createMetricButton(ml, "Мл"));
    ingredientContainer.append(createMetricButton(g, "Грамм"));
    ingredientContainer.append(recipeIdInput);

    container.append(ingredientContainer);
}

/**
 * Shows the metric's label and input.
 * Hides other metrics' buttons.
 * @param {string} metricClassName
 */
function activateMetric(metricClassName) {
    $(".metric-radio-button").hide();
    var elements = document.getElementsByClassName(metricClassName).length;
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.display = "normal";
    }
}

/**
 * Creates a button specific to the provided metric.
 * @param {string} metricName The name of the metric e.g. "Amount".
 * @param {string} buttonText The text to display on the button.
 */
function createMetricButton(metricName, buttonText) {
    var button = document.createElement("button");

    button.setAttribute("class", "btn btn-outline-primary metric-radio-button");
    button.setAttribute("type", "button");
    button.setAttribute("onclick",`activateMetric(${metricName})`);
    button.innerHTML = buttonText;

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
    label.setAttribute("class", `control-label ${name}`);
    label.setAttribute("id", `${name}Label${index}`);
    label.innerHTML = labelHtml;
    label.style.display = "none";

    let input = document.createElement("input");
    input.setAttribute("class", `form-control ${name}`);
    input.setAttribute("type", "number");
    input.setAttribute("id", `${name}Input${index}`);
    input.setAttribute("name", `${current}.${name}`);
    input.style.display = "none";

    let elements = [label, input];

    return elements;
}