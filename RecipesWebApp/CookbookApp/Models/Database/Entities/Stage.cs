using System;
using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.Database.Entities
{
    public class Stage
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int Index { get; set; }
        public string Description { get; set; }
    }
}