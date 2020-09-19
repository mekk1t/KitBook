using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Repositories.Filters;
using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        void AddNewRecipe(Recipe newRecipe);
        void EditRecipeById(Guid recipeId, Recipe editRecipe);
        void AddCommentToRecipe(Guid recipeId, Comment newComment);
        void RemoveCommentFromRecipe(Guid commentId);
        void EditCommentToRecipe(Guid commentId, string newCommentText);
        void AddIngredientToRecipe(Guid recipeId, Guid ingredientId);
        void RemoveIngredientFromRecipe(Guid recipeId, Guid ingredientId);
        void EditRecipeIngredientInfo(Guid recipeId, Guid ingredientId, RecipeIngredientInfo info);

        void AddStagesToRecipe(Guid recipeId, List<Stage> stages);
        void RemoveStageFromRecipe(Guid stageId);
        IEnumerable<Stage> GetRecipeStages(Guid recipeId);

        Recipe GetRecipeById(Guid recipeId);
        IEnumerable<Recipe> GetRecipes(int pageNumber = 1);
        IEnumerable<Recipe> GetRecipesFiltered(RecipeFilter filter);
        IEnumerable<Recipe> GetRecipesByIngredients(List<Guid> ingredientIds);
        IEnumerable<Recipe> SearchRecipesByName_ExactMatch(string searchText);
        IEnumerable<Recipe> SearchRecipesByName_Occurrences(string searchText);
    }
}
