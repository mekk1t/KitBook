using System;
using System.Collections.Generic;
using System.Linq;
using KitBook.Helpers.Extensions;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitBook.Models.Repositories
{
    public class IngredientRepository : IRepositoryAdvanced<Ingredient>
    {
        private readonly CookbookDbContext dbContext;

        public IngredientRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Ingredient entity)
        {
            dbContext.Ingredients.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var ingredient = dbContext.Ingredients.FirstOrDefault(i => i.Id == id);
            dbContext.Ingredients.Remove(ingredient);
            dbContext.SaveChanges();
        }

        public Ingredient Read(Guid id)
        {
            return dbContext.Ingredients.AsNoTracking().FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Ingredient> Read()
        {
            return dbContext.Ingredients.AsNoTracking().Paged().AsEnumerable();
        }

        public Ingredient ReadWithRelationships(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> ReadWithRelationships()
        {
            throw new NotImplementedException();
        }

        public void Update(Ingredient entity)
        {
            var ingredient = dbContext.Ingredients.FirstOrDefault(i => i.Id == entity.Id);
            ingredient = entity;
            dbContext.SaveChanges();
        }
    }
}
