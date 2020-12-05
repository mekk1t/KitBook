using BusinessLogic.Models;
using KitBook.Abstractions;
using KitBook.ViewModels;

namespace KitBook.Mappers
{
    public interface IIngredientMapper :
        IMapper<Ingredient, IngredientViewModel>,
        IMapper<RecipeIngredient, RecipeIngredientViewModel>,
        IMapper<EditIngredient, Ingredient>,
        IMapper<NewIngredient, Ingredient>,
        IMapper<RecipeIngredientViewModel, RecipeIngredient>,
        IEditMapper<Ingredient, EditIngredient>
    {
    }
}
