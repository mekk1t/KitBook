using BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IIngredientService
    {
        void CreateNewIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        void DeleteIngredientById(Guid id);
        Ingredient GetIngredientById(Guid id);
        IEnumerable<Ingredient> GetIngredients(int pageSize = 10, int pageNumber = 1);
    }
}