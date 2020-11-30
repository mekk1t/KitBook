using System;

namespace KitBook.Models.ViewModels.Ingredient
{
    public class NewIngredient
    {
        public string Name { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSugary { get; set; }
        public bool IsSour { get; set; }
        public Guid? IngredientTypeId { get; set; }
    }
}
