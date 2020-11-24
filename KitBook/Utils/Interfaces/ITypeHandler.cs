using System.Collections.Generic;
using KitBook.Models.Database.Entities.Types;

namespace KitBook.Handlers.Interfaces
{
    public interface ITypeHandler
    {
        IEnumerable<RecipeType> GetRecipeTypes();
        IEnumerable<CookingType> GetCookingTypes();
        IEnumerable<DishType> GetDishTypes();
        IEnumerable<IngredientType> GetIngredientTypes();
    }
}
