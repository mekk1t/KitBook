using KK.Cookbook.Models.DTO;
using System;

namespace KK.Cookbook.Models.Commands.Interfaces
{
    public interface ICreateNewRecipeCommand
    {
        Guid Execute(RecipeDto recipe);
    }
}
