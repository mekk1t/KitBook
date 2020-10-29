using KitBook.Models.Database.Entities.Types;
using System.Collections.Generic;

namespace KitBook.Models.Repositories.Interfaces
{
    public interface ITypeRepository
    {
        public void AddNewRecipeType(string name);
        public void AddNewCookingType(string name);
        public void AddNewDishType(string name);
        public void AddNewIngredientType(string name);

        public IEnumerable<RecipeType> GetRecipeTypes();
        public IEnumerable<CookingType> GetCookingTypes();
        public IEnumerable<DishType> GetDishTypes();
        public IEnumerable<IngredientType> GetIngredientTypes();

        public void RemoveRecipeType(string name);
        public void RemoveCookingType(string name);
        public void RemoveDishType(string name);
        public void RemoveIngredientType(string name);
    }
}
