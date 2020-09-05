using mekk1t.Cookbook.Models.Database.Entities.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesWebApp.Models.Database.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeCategory> Recipes { get; set; }
        public Image Image { get; set; }
    }
}