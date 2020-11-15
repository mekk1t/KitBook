using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace KitBook.Models.DTO
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Время готовки")]
        public int CookingTimeMinutes { get; set; }
        [Display(Name = "Источник")]
        public string SourceURL { get; set; }

        [Display(Name = "Тип готовки")]
        public Guid? CookingTypeId { get; set; }
        [Display(Name = "Тип рецепта")]
        public Guid? RecipeTypeId { get; set; }
        [Display(Name = "Тип блюда")]
        public Guid? DishTypeId { get; set; }

        public string CookingType { get; set; }
        public string RecipeType { get; set; }
        public string DishType { get; set; }

        [Display(Name = "Обложка")]
        public IFormFile Thumbnail { get; set; }

        public string ThumbnailBase64 { get; set; }
        public string ThumbnailContentType { get; set; }

        public List<StageDto> Stages { get; set; }

        [Display(Name = "Ингредиенты")]
        public List<RecipeIngredientDto> Ingredients { get; set; }
    }
}
