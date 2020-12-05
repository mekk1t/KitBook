using BusinessLogic.Abstractions;
using BusinessLogic.Models;
using System.Collections.Generic;

namespace KitBook.Utils
{
    public class TypeHandler : ITypeHandler
    {
        private readonly IRepositoryAdvanced<CookingType> cookingTypeRepository;
        private readonly IRepositoryAdvanced<DishType> dishTypeRepository;
        private readonly IRepositoryAdvanced<RecipeType> recipeTypeRepository;
        private readonly IRepositoryAdvanced<IngredientType> ingredientTypeRepository;

        public TypeHandler(
            IRepositoryAdvanced<CookingType> cookingTypeRepository,
            IRepositoryAdvanced<DishType> dishTypeRepository,
            IRepositoryAdvanced<IngredientType> ingredientTypeRepository,
            IRepositoryAdvanced<RecipeType> recipeTypeRepository)
        {
            this.cookingTypeRepository = cookingTypeRepository;
            this.dishTypeRepository = dishTypeRepository;
            this.ingredientTypeRepository = ingredientTypeRepository;
            this.recipeTypeRepository = recipeTypeRepository;
        }

        public IEnumerable<CookingType> GetCookingTypes()
        {
            return cookingTypeRepository.GetList();
        }

        public IEnumerable<DishType> GetDishTypes()
        {
            return dishTypeRepository.GetList();
        }

        public IEnumerable<IngredientType> GetIngredientTypes()
        {
            return ingredientTypeRepository.GetList();
        }

        public IEnumerable<RecipeType> GetRecipeTypes()
        {
            return recipeTypeRepository.GetList();
        }
    }
}
