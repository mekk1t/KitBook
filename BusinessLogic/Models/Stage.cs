using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Models.Files;

namespace KitBook.Models.Database.Entities
{
    public class Stage
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int Index { get; set; }
        public string Description { get; set; }
        public Guid? ImageId { get; set; }
        public File Image { get; set; }
    }
}