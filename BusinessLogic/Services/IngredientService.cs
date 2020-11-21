using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using KitBook.Models.Database.Entities;
using KitBook.Models.Services.Interfaces;

namespace KitBook.Models.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryAdvanced<Ingredient> repository;

        public IngredientService(IRepositoryAdvanced<Ingredient> repository)
        {
            this.repository = repository;
        }

        public void CreateNewIngredient(Ingredient ingredient)
        {
            repository.Create(ingredient);
        }

        public void DeleteIngredientById(Guid id)
        {
            repository.DeleteById(id);
        }

        public Ingredient GetIngredientById(Guid id)
        {
            return repository.GetByIdWithRelationships(id);
        }

        public IEnumerable<Ingredient> GetIngredients(int pageSize = 10, int pageNumber = 1)
        {
            return repository.GetListWithRelationships();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            repository.Update(ingredient);
        }
    }
}
