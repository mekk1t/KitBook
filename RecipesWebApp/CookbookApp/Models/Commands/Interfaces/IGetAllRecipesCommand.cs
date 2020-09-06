using KK.Cookbook.Models.DTO;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Commands.Interfaces
{
    public interface IGetAllRecipesCommand
    {
        IEnumerable<RecipeDto> Execute();
    }
}
