using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitBook.ViewModels
{
    public class IngredientViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Острый")]
        public bool IsSpicy { get; set; }
        [Display(Name = "Содержит сахар")]
        public bool IsSugary { get; set; }
        [Display(Name = "Кислый")]
        public bool IsSour { get; set; }
        [Display(Name = "Тип")]
        public Guid IngredientTypeId { get; set; }

        public IEnumerable<IngredientRecipeReference> References { get; set; }

        public string IngredientType { get; set; }
    }
}
