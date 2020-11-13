using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitBook.Models.Database.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RecipeCategory> Recipes { get; set; }
    }
}
