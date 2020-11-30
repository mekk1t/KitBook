using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KitBook.Models.ViewModels.Stage;
using Microsoft.AspNetCore.Http;

namespace KitBook.Models.ViewModels.Recipe
{
    public class EditRecipe
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

        [Display(Name = "Тип готовки")]
        public Guid? CookingTypeId { get; set; }
        [Display(Name = "Тип рецепта")]
        public Guid? RecipeTypeId { get; set; }
        [Display(Name = "Тип блюда")]
        public Guid? DishTypeId { get; set; }

        [Display(Name = "Обложка")]
        public IFormFile Thumbnail { get; set; }

        public List<EditStage> Stages { get; set; }
        public List<RecipeIngredientViewModel> Ingredients { get; set; }

        public ImageViewModel ExistingImage { get; set; }
    }
}
