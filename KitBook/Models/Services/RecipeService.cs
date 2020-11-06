using System;
using System.Collections.Generic;
using KitBook.Helpers.Extensions;
using KitBook.Models.Database.Entities;
using KitBook.Models.DTO;
using KitBook.Models.Repositories.Interfaces;
using KitBook.Models.Services.Interfaces;

namespace KitBook.Models.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepositoryAdvanced<Recipe> repository;

        public RecipeService(IRepositoryAdvanced<Recipe> repository)
        {
            this.repository = repository;
        }

        public void CreateNewRecipe(RecipeDto dto)
        {
            repository.Create(dto.AsNewEntity());
        }

        public void DeleteRecipeById(Guid id)
        {
            repository.Delete(id);
        }

        public RecipeDto GetRecipeById(Guid id)
        {
            return repository.ReadWithRelationships(id).AsDto();
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            return repository.ReadWithRelationships().AsDtoEnumerable();
        }

        public void UpdateRecipe(RecipeDto dto)
        {
            repository.Update(dto.AsEntity());
        }
    }
}
