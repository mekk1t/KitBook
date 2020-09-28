using System;

namespace KK.Cookbook.Models.ViewData
{
    public class RecipeIngredientViewData
    {
        internal Guid RecipeId { get; set; }
        internal Guid IngredientId { get; set; }
        public IngredientViewData Ingredient { get; set; }
    }
}