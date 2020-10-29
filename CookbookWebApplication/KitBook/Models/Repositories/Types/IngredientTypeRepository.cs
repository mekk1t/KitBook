using System;
using System.Collections.Generic;
using System.Linq;
using KitBook.Helpers.Extensions;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitBook.Models.Repositories.Types
{
    public class IngredientTypeRepository : IRepository<IngredientType>
    {
        private readonly CookbookDbContext dbContext;

        public IngredientTypeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(IngredientType entity)
        {
            dbContext.IngredientTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var type = dbContext.IngredientTypes.FirstOrDefault(it => it.Id == id);
            dbContext.IngredientTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public void Update(IngredientType entity)
        {
            var ingredientType = dbContext.IngredientTypes.FirstOrDefault(it => it.Id == entity.Id);
            ingredientType = entity;
            dbContext.SaveChanges();
        }

        public IngredientType Read(Guid id)
        {
            return dbContext.IngredientTypes.AsNoTracking().FirstOrDefault(it => it.Id == id);
        }

        public IEnumerable<IngredientType> Read()
        {
            return dbContext.IngredientTypes.AsNoTracking().Paged().AsEnumerable();
        }
    }
}