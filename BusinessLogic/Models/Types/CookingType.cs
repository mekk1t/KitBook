using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Abstractions;
using BusinessLogic.Attributes;

namespace BusinessLogic.Models
{
    [Translation("Способ приготовления")]
    public class CookingType : IType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public File Icon { get; set; }
    }
}