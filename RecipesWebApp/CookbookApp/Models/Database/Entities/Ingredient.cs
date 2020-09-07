using KK.Cookbook.Models.Database.Entities.Types;
using System;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Database.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsSpicy { get; set; }
        public bool? IsSugary{ get; set; }
        public bool? IsSour { get; set; }
        public ICollection<RecipeIngredient> Recipes { get; set; }
        public Guid IngredientTypeId { get; set; }
        public IngredientType Type { get; set; }
    }
}