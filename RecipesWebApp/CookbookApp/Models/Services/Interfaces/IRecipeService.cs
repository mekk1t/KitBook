using KK.Cookbook.Models.ViewData;
using System;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Services.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipeViewData> GetRecipes();
        Guid AddNewRecipe(RecipeViewData recipe);
        void RemoveRecipe(Guid recipeId);
    }
}
