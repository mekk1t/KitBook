using System;
using BusinessLogic.Abstractions;
using BusinessLogic.Attributes;

namespace BusinessLogic.Models
{
    [Translation("Тип ингредиента")]
    public class IngredientType : IType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public File Icon { get; set; }
    }
}
