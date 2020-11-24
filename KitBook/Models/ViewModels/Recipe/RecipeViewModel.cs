using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitBook.Models.ViewModels
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Время готовки")]
        public int? CookingTimeMinutes { get; set; }
        [Display(Name = "Источник")]
        public string SourceURL { get; set; }
        public string CookingType { get; set; }
        public string RecipeType { get; set; }
        public string DishType { get; set; }

        public ImageViewModel Thumbnail { get; set; }
        public ImageViewModel CookingTypeIcon { get; set; }

        public List<StageViewModel> Stages { get; set; }
        public List<RecipeIngredientViewModel> Ingredients { get; set; }
    }
}
