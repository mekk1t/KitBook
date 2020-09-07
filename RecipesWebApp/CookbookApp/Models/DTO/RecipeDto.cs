using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.DTO
{
    public class RecipeDto
    {
        [Required(ErrorMessage = "Введите название.")]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "ч.")]
        public int Hours { get; set; }
        [Display(Name = "мин.")]
        public int Minutes { get; set; }

        [Display(Name = "Тип готовки")]
        public string CookingType { get; set; }
        [Display(Name = "Тип рецепта")]
        public string RecipeType { get; set; }
        [Display(Name = "Тип блюда")]
        public string DishType { get; set; }

        public string SourceURL { get; set; }
    }
}
