const ingredientsId = "#ingredients";

function moreIngredients() {
    let _container = document.getElementById(ingredientsId);
    let _childrenLength = _container.children(".ingredientsDiv").length;

    appendIngredientToContainer(_childrenLength, _container);
}

function appendIngredientToContainer(i, container) {
    var currentIngredient = "Ingredients".concat("[", i, "]");

    var ingredientContainer = document.createElement("div");
    ingredientContainer.setAttribute("class", "count");

    let nameLabel = createLabel(new Label("control-label", "Название"));

    var _select = document.createElement("select");
    _select.setAttribute("class", "form-control");
    _select.setAttribute("name", currentIngredient.concat(".IngredientId"));
    _select.setAttribute("id", "ingredientsSelect".concat("_", i));
    $(_select).load(window.location.origin.concat("/Ingredient", "/IngredientsSelectList"));

    var mlButtonValues =
        new Button(
            "btn btn-outline-primary",
            "mlButton".concat(i),
            "button",
            currentIngredient.concat(".Ml"),
            "МЛ",
            "showMl(".concat(i, ")"));
    var mlButton = createSubmitButton(mlButtonValues);

    var mlButton = document.createElement("button");
    mlButton.setAttribute("class", "btn btn-outline-primary");
    mlButton.setAttribute("value", currentIngredient.concat(".Ml"));
    mlButton.setAttribute("id", "mlButton".concat(i));
    mlButton.setAttribute("type", "button");
    mlButton.innerHTML = "МЛ";
    mlButton.setAttribute("onclick", "showMl(".concat(i, ")"));

    var gButton = document.createElement("button");
    gButton.setAttribute("class", "btn btn-outline-primary");
    gButton.setAttribute("value", currentIngredient.concat(".G"));
    gButton.setAttribute("id", "gButton".concat(i));
    gButton.setAttribute("type", "button");
    gButton.setAttribute("onclick", "showG(".concat(i, ")"));
    gButton.innerHTML = "В граммах";

    var aButton = document.createElement("button");
    aButton.setAttribute("class", "btn btn-outline-primary");
    aButton.setAttribute("value", currentIngredient.concat(".Amount"));
    aButton.setAttribute("id", "aButton".concat(i));
    aButton.setAttribute("type", "button");
    aButton.setAttribute("onclick", "showAmount(".concat(i, ")"));
    aButton.innerHTML = "Поштучно";

    var recipeIdInput = document.createElement("input");
    recipeIdInput.setAttribute("class", "invisible");
    recipeIdInput.setAttribute("name", currentIngredient.concat(".RecipeId"));
    recipeIdInput.setAttribute("value", $("#Id").val())

    ingredientContainer.appendChild(nameLabel);
    ingredientContainer.appendChild(_select);
    appendMl(mlButton, ingredientContainer, i);
    appendG(gButton, ingredientContainer, i);
    appendAmount(aButton, ingredientContainer, i);
    ingredientContainer.appendChild(gButton);
    ingredientContainer.appendChild(mlButton);
    ingredientContainer.appendChild(aButton);
    ingredientContainer.appendChild(recipeIdInput);

    container.append(ingredientContainer);
}

function showMl(i) {
    $("#mlLabel".concat(i)).show();
    $("#mlInput".concat(i)).show();
    $("#mlButton".concat(i)).hide();
    $("#gButton".concat(i)).hide();
    $("#aButton".concat(i)).hide();
}

function showG(i) {
    $("#gLabel".concat(i)).show();
    $("#gInput".concat(i)).show();
    $("#mlButton".concat(i)).hide();
    $("#gButton".concat(i)).hide();
    $("#aButton".concat(i)).hide();
}

function showAmount(i) {
    $("#aLabel".concat(i)).show();
    $("#aInput".concat(i)).show();
    $("#mlButton".concat(i)).hide();
    $("#gButton".concat(i)).hide();
    $("#aButton".concat(i)).hide();
}

function appendMl(button, container, i) {
    var mlLabel = document.createElement("label");
    mlLabel.setAttribute("class", "control-label");
    mlLabel.style.display = "none";
    mlLabel.setAttribute("id", "mlLabel".concat(i));
    mlLabel.innerHTML = "Объем (в мл.)";
    var mlInput = document.createElement("input");
    mlInput.setAttribute("class", "form-control");
    mlInput.setAttribute("id", "mlInput".concat(i));
    mlInput.style.display = "none";
    mlInput.setAttribute("type", "number");
    mlInput.setAttribute("name", $(button).val());

    container.appendChild(mlLabel);
    container.appendChild(mlInput);
}

function appendG(button, container, i) {
    var gLabel = document.createElement("label");
    gLabel.setAttribute("class", "control-label");
    gLabel.style.display = "none";
    gLabel.setAttribute("id", "gLabel".concat(i));
    gLabel.innerHTML = "Грамм";
    var gInput = document.createElement("input");
    gInput.setAttribute("class", "form-control");
    gInput.style.display = "none";
    gInput.setAttribute("type", "number");
    gInput.setAttribute("id", "gInput".concat(i));
    gInput.setAttribute("name", $(button).val());

    container.appendChild(gLabel);
    container.appendChild(gInput);
}

function appendAmount(button, container, i) {
    var aLabel = document.createElement("label");
    aLabel.setAttribute("class", "control-label");
    aLabel.style.display = "none";
    aLabel.setAttribute("id", "aLabel".concat(i));
    aLabel.innerHTML = "Штук";
    var aInput = document.createElement("input");
    aInput.setAttribute("class", "form-control");
    aInput.style.display = "none";
    aInput.setAttribute("type", "number");
    aInput.setAttribute("id", "aInput".concat(i));
    aInput.setAttribute("name", $(button).val());

    container.appendChild(aLabel);
    container.appendChild(aInput);
}
