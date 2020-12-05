using BusinessLogic.Models;
using KitBook.Abstractions;
using KitBook.ViewModels;

namespace KitBook.Mappers
{
    public interface IRecipeMapper :
        IMapper<Recipe, RecipeViewModel>,
        IMapper<NewRecipe, Recipe>,
        IMapper<EditRecipe, Recipe>,
        IEditMapper<Recipe, EditRecipe>
    {
    }
}
