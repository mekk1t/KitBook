using System;

namespace KitBook.Models.ViewModels
{
    public class RecipeIngredientViewModel
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int? Amount { get; set; }
        public int? G { get; set; }
        public int? Ml { get; set; }
    }
}
