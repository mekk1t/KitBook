using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CookingTimeMinutes { get; set; }
        public string SourceURL { get; set; }

        public Guid? CookingTypeId { get; set; }
        public Guid? RecipeTypeId { get; set; }
        public Guid? DishTypeId { get; set; }
        public Guid? ThumbnailId { get; set; }

        public File Thumbnail { get; set; }
        public CookingType CookingType { get; set; }
        public RecipeType RecipeType { get; set; }
        public DishType DishType { get; set; }

        public IEnumerable<RecipeCategory> Categories { get; set; }
        public IEnumerable<RecipeIngredient> Ingredients { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Stage> Stages { get; set; }
    }
}