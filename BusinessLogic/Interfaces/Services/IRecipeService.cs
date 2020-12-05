using BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IRecipeService
    {
        void CreateNewRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipeById(Guid id);
        Recipe GetRecipeById(Guid id);
        IEnumerable<Recipe> GetRecipes();
    }
}
