using System;
using System.Collections.Generic;
using KitBook.Helpers.Extensions;
using KitBook.Models.Database.Entities;
using KitBook.Models.DTO;
using KitBook.Models.Repositories.Interfaces;
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

        public void CreateNewIngredient(IngredientDto dto)
        {
            repository.Create(dto.AsEntity());
        }

        public void DeleteIngredientById(Guid id)
        {
            repository.Delete(id);
        }

        public IngredientDto GetIngredientById(Guid id)
        {
            return repository.Read(id).AsDto();
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            return repository.ReadWithRelationships().AsDtoEnumerable();
        }

        public void UpdateIngredient(IngredientDto dto)
        {
            repository.Update(dto.AsEntity());
        }
    }
}
