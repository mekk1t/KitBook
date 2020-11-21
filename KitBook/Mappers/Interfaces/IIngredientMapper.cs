using BusinessLogic.Interfaces.Mappers;
using KitBook.Models.Database.Entities;
using KitBook.Models.ViewModels;
using KitBook.Models.ViewModels.Ingredient;

namespace KitBook.Mappers.Interfaces
{
    public interface IIngredientMapper :
        IMapper<Ingredient, IngredientViewModel>,
        IMapper<RecipeIngredient, RecipeIngredientViewModel>,
        IMapper<EditIngredient, Ingredient>,
        IMapper<NewIngredient, Ingredient>,
        IMapper<RecipeIngredientViewModel, RecipeIngredient>
    {}
}
