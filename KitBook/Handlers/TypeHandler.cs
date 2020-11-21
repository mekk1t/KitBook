using System.Collections.Generic;
using BusinessLogic.Interfaces;
using KitBook.Handlers.Interfaces;
using KitBook.Models.Database.Entities.Types;

namespace KitBook.Handlers
{
    public class TypeHandler : ITypeHandler
    {
        private readonly IRepository<CookingType> cookingTypeRepository;
        private readonly IRepository<DishType> dishTypeRepository;
        private readonly IRepository<RecipeType> recipeTypeRepository;
        private readonly IRepository<IngredientType> ingredientTypeRepository;

        public TypeHandler(
            IRepository<CookingType> cookingTypeRepository,
            IRepository<DishType> dishTypeRepository,
            IRepository<IngredientType> ingredientTypeRepository,
            IRepository<RecipeType> recipeTypeRepository)
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
