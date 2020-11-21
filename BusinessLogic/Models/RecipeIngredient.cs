using System;

namespace KitBook.Models.Database.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int? Amount { get; set; }
        public int? G { get; set; }
        public int? Ml { get; set; }
    }

}