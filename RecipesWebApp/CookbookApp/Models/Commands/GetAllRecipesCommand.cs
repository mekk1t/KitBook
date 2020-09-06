using KK.Cookbook.Models.Commands.Interfaces;
using KK.Cookbook.Models.Database.Entities;
using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.Repositories.Interfaces;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Commands
{
    public class GetAllRecipesCommand : IGetAllRecipesCommand
    {
        private readonly IMapper<IEnumerable<Recipe>, IEnumerable<RecipeDto>> mapper;
        private readonly IRecipeRepository repository;

        public GetAllRecipesCommand(
            IMapper<IEnumerable<Recipe>, IEnumerable<RecipeDto>> mapper,
            IRecipeRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<RecipeDto> Execute()
        {
            return mapper.Map(repository.GetRecipes());
        }
    }
}
