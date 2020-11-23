using System;
using BusinessLogic.Models.Files;
using BusinessLogic.Models.Types.Interface;

namespace KitBook.Models.Database.Entities.Types
{
    public class RecipeType : IType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public File Icon { get; set; }
    }
}
