using mekk1t.Cookbook.Models.Database.Entities.Custom;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecipesWebApp.Models.Database.Entities
{
    public class Stage
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int Index { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
    }
}
