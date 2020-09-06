using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Repositories.Filters;
using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Guid AddNewRecipe(Recipe newRecipe);
        Recipe GetRecipeById(Guid recipeId);
        void EditRecipeById(Guid recipeId, Recipe editRecipe);

        IEnumerable<Recipe> GetRecipes(int pageNumber = 1);
        IEnumerable<Recipe> GetRecipesFiltered(RecipeFilter filter);
        IEnumerable<Recipe> GetRecipesByIngredients(List<Guid> ingredientIds);
        IEnumerable<Recipe> GetRecipesByCategories(List<Guid> categoriesIds);
        IEnumerable<Recipe> SearchRecipesByName_ExactMatch(string searchText);
        IEnumerable<Recipe> SearchRecipesByName_Occurrences(string searchText);

        void AddCommentToRecipe(Guid recipeId, Comment newComment);
        void RemoveCommentFromRecipe(Guid commentId);
        void EditCommentToRecipe(Guid commentId, string newCommentText);

        // many-to-many operations
        // UPD: Сначала добавить просто рецепт, потом добавить просто ингредиент И ЛИШЬ ЗАТЕМ СОЕДИИНИТЬ ИХ ОТДЕЛЬНЫМ МЕТОДОМ В БД
        // МЕТОДЫ ДЛЯ M:M -- ОТДЕЛЬНЫЕ!
        void AddIngredientToRecipe(Guid recipeId, Guid ingredientId);
        void RemoveIngredientFromRecipe(Guid recipeId, Guid ingredientId);
        void EditRecipeIngredientInfo(Guid recipeId, Guid ingredientId, RecipeIngredientInfo info);

        void EditRecipeCategory(Guid recipeId, List<Guid> categoriesIds);
        void RemoveCategoryFromRecipe(Guid recipeId, Guid categoryId);
        void AddCategoryToRecipe(Guid recipeId, Guid categoryId);
    }
}
