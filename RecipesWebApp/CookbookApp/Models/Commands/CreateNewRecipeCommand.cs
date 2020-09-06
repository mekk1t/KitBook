using KK.Cookbook.Models.Commands.Interfaces;
using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.Repositories.Interfaces;
using KK.Cookbook.Models.Database.Entities;
using System;

namespace KK.Cookbook.Models.Commands
{
    public class CreateNewRecipeCommand : ICreateNewRecipeCommand
    {
        private readonly IMapper<RecipeDto, Recipe> mapper;
        private readonly IRecipeRepository repository;

        public CreateNewRecipeCommand(IMapper<RecipeDto, Recipe> mapper, IRecipeRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public Guid Execute(RecipeDto recipe)
        {
            return repository.AddNewRecipe(mapper.Map(recipe));
        }
    }
}
