using KK.Cookbook.Models.Database.Entities;
using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KK.Cookbook.Models.Mappers
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
