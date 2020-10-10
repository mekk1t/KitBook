using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KK.Cookbook.Models.ViewData
{
    public class RecipeViewData
    {
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public string RecipeType { get; set; }
        public string DishType { get; set; }
        public string CookingType { get; set; }

        public string SourceURL { get; set; }

        public int StagesCount => Stages.Count();
        public int CommentsCount => Comments.Count();
        public IEnumerable<StageViewData> Stages { get; set; }
        public IEnumerable<CommentViewData> Comments { get; set; }
        public IEnumerable<IngredientViewData> Ingredients { get; set; }
    }
}