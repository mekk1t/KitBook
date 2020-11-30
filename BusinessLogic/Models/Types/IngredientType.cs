using System;
using BusinessLogic.Attributes;
using BusinessLogic.Models.Files;
using BusinessLogic.Models.Types.Interface;

namespace KitBook.Models.Database.Entities.Types
{
    [Translation("Тип ингредиента")]
    public class IngredientType : IType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public File Icon { get; set; }
    }
}
