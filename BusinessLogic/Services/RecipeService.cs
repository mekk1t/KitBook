using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using KitBook.Models.Database.Entities;
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

        public void CreateNewRecipe(Recipe recipe)
        {
            repository.Create(recipe);
        }

        public void DeleteRecipeById(Guid id)
        {
            repository.DeleteById(id);
        }

        public Recipe GetRecipeById(Guid id)
        {
            var recipe = repository.GetByIdWithRelationships(id);

            if (recipe.Stages?.Count > 0)
            {
                var stages = recipe.Stages;
                recipe.Stages = stages.OrderBy(s => s.Index).ToList();
            }

            return recipe;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return repository.GetListWithRelationships();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            repository.Update(recipe);
        }
    }
}
