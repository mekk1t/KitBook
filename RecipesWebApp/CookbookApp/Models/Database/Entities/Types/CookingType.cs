using System;
using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.Database.Entities.Types
{
    public class CookingType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}