using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId);
        IEnumerable<Ingredient> GetIngredients();
        void AddNewIngredient(Ingredient ingredient);
        void RemoveIngredient(Guid ingredientId);
    }
}
