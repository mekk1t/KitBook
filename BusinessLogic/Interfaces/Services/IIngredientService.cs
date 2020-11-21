using System;
using System.Collections.Generic;
using KitBook.Models.DTO;

namespace KitBook.Models.Services.Interfaces
{
    public interface IIngredientService
    {
        void CreateNewIngredient(IngredientDto dto);
        void UpdateIngredient(IngredientDto dto);
        void DeleteIngredientById(Guid id);
        IngredientDto GetIngredientById(Guid id);
        IEnumerable<IngredientDto> GetIngredients();
    }
}