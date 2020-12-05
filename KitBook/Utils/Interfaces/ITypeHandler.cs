using BusinessLogic.Models;
using System.Collections.Generic;

namespace KitBook.Utils
{
    public interface ITypeHandler
    {
        IEnumerable<RecipeType> GetRecipeTypes();
        IEnumerable<CookingType> GetCookingTypes();
        IEnumerable<DishType> GetDishTypes();
        IEnumerable<IngredientType> GetIngredientTypes();
    }
}
