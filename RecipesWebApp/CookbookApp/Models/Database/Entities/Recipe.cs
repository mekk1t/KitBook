using KK.Cookbook.Models.Database.Entities.Custom;
using KK.Cookbook.Models.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.Database.Entities
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan CookingTime { get; set; }
        public CookingType CookingType { get; set; }
        public RecipeType RecipeType { get; set; }
        public DishType DishType { get; set; }
        public string SourceURL { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }
        public List<RecipeCategory> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Stage> Stages { get; set; }
        public Image Image { get; set; }
    }
}