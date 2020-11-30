using System;

namespace KitBook.Models.ViewModels.Ingredient
{
    public class EditIngredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSugary { get; set; }
        public bool IsSour { get; set; }
        public Guid? IngredientTypeId { get; set; }
    }
}