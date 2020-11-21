using System;

namespace KitBook.Models.DTO
{
    public class RecipeIngredientDto
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public int? G { get; set; }
        public int? Ml { get; set; }
    }
}