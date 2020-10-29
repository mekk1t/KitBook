using KitBook.Models.ViewData;
using System;
using System.Collections.Generic;

namespace KitBook.Models.Services.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipeViewData> GetRecipes();
        Guid AddNewRecipe(RecipeViewData recipe);
        void RemoveRecipe(Guid recipeId);
    }
}
