using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Models.Files;

namespace KitBook.Models.Database.Entities.Types
{
    public class CookingType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public File Icon { get; set; }
    }
}