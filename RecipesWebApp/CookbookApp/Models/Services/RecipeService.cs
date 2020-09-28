using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.Repositories.Interfaces;
using KK.Cookbook.Models.Services.Interfaces;
using KK.Cookbook.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.Cookbook.Models.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository repository;
        private readonly IRecipeMapper mapper;

        public RecipeService(IRecipeRepository repository, IRecipeMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Guid AddNewRecipe(RecipeViewData recipe)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipeViewData> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public void RemoveRecipe(Guid recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
