using System;
using System.ComponentModel.DataAnnotations;

namespace KitBook.Models.ViewModels.Ingredient
{
    public class NewIngredient
    {
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Острый")]
        public bool IsSpicy { get; set; }
        [Display(Name = "Содержит сахар")]
        public bool IsSugary { get; set; }
        [Display(Name = "Кислый")]
        public bool IsSour { get; set; }
        [Display(Name = "Тип")]
        public Guid? IngredientTypeId { get; set; }
    }
}
