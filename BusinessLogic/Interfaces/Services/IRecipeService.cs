using System;
using System.Collections.Generic;
using KitBook.Models.Database.Entities;

namespace KitBook.Models.Services.Interfaces
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
