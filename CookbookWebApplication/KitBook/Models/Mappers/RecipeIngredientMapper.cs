using KitBook.Models.Database.Entities;
using KitBook.Models.Mappers.Interfaces;
using KitBook.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitBook.Models.Mappers
{
    public class RecipeIngredientMapper : IRecipeIngredientMapper
    {
        public IEnumerable<IngredientViewData> Map(IEnumerable<RecipeIngredient> model)
        {
            var result = new List<IngredientViewData>();

            foreach (var ri in model)
            {
                result.Add(new IngredientViewData
                {
                    Name = ri.Ingredient.Name,
                    IsOptional = ri.IsOptional,
                    Amount = ri.Amount,
                    G = ri.G,
                    Ml = ri.Ml
                });
            }

            return result.AsEnumerable();
        }
    }
}
