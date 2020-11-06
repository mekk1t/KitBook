function moreIngredients() {
    var ingredientsContainer = $("#ingredients");
    appendIngredientToContainer(ingredientsContainer.children(".count").length, ingredientsContainer);
}

function appendIngredientToContainer(i, container) {
    var currentIngredient = "Ingredients".concat("[", i, "]");

    var ingredientContainer = document.createElement("div");
    ingredientContainer.setAttribute("class", "count");

    var nameLabel = document.createElement("label");
    nameLabel.setAttribute("class", "control-label");
    nameLabel.innerHTML = "Название";

    var _select = document.createElement("select");
    _select.setAttribute("class", "form-control");
    _select.setAttribute("name", currentIngredient.concat(".IngredientId"));
    _select.setAttribute("id", "ingredientsSelect".concat("_", i));
    $(_select).load(window.location.origin.concat("/Ingredient", "/IngredientsSelectList"));

    var gLabel = document.createElement("label");
    gLabel.setAttribute("class", "control-label");
    gLabel.innerHTML = "Грамм";
    var gInput = document.createElement("input");
    gInput.setAttribute("class", "form-control");
    gInput.setAttribute("type", "number");
    gInput.setAttribute("name", currentIngredient.concat(".G"));

    var mlLabel = document.createElement("label");
    mlLabel.setAttribute("class", "control-label");
    mlLabel.innerHTML = "Объем (в мл.)";
    var mlInput = document.createElement("input");
    mlInput.setAttribute("class", "form-control");
    mlInput.setAttribute("type", "number");
    mlInput.setAttribute("name", currentIngredient.concat(".Ml"));

    var aLabel = document.createElement("label");
    aLabel.setAttribute("class", "control-label");
    aLabel.innerHTML = "Штук";
    var aInput = document.createElement("input");
    aInput.setAttribute("class", "form-control");
    aInput.setAttribute("type", "number");
    aInput.setAttribute("name", currentIngredient.concat(".Amount"));


    var recipeIdInput = document.createElement("input");
    recipeIdInput.setAttribute("class", "invisible");
    recipeIdInput.setAttribute("name", currentIngredient.concat(".RecipeId"));
    recipeIdInput.setAttribute("value", $("#Id").val())

    ingredientContainer.appendChild(nameLabel);
    ingredientContainer.appendChild(_select);
    ingredientContainer.appendChild(gLabel);
    ingredientContainer.appendChild(gInput);
    ingredientContainer.appendChild(mlLabel);
    ingredientContainer.appendChild(mlInput);
    ingredientContainer.appendChild(aLabel);
    ingredientContainer.appendChild(aInput);
    ingredientContainer.appendChild(recipeIdInput);

    container.append(ingredientContainer);
}