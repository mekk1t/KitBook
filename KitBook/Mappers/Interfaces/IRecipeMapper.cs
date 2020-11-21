using BusinessLogic.Interfaces.Mappers;
using KitBook.Models.Database.Entities;
using KitBook.Models.ViewModels;
using KitBook.Models.ViewModels.Recipe;

namespace KitBook.Mappers.Interfaces
{
    public interface IRecipeMapper : IMapper<Recipe, RecipeViewModel>, IMapper<NewRecipe, Recipe>, IMapper<EditRecipe, Recipe>
    {
    }
}
