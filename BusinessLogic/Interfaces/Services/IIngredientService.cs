using System;
using System.Collections.Generic;
using KitBook.Models.Database.Entities;

namespace KitBook.Models.Services.Interfaces
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