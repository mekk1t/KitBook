using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities.Types;
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

        public void DeleteById(Guid id)
        {
            var type = dbContext.IngredientTypes.FirstOrDefault(it => it.Id == id);
            dbContext.IngredientTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public void Update(IngredientType entity)
        {
            var ingredientType = dbContext.IngredientTypes.FirstOrDefault(it => it.Id == entity.Id);
            ingredientType.Name = entity.Name;
            dbContext.SaveChanges();
        }

        public IngredientType GetById(Guid id)
        {
            return dbContext.IngredientTypes.AsNoTracking().FirstOrDefault(it => it.Id == id);
        }

        public IEnumerable<IngredientType> GetList(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.IngredientTypes.AsNoTracking().AsEnumerable();
        }
    }
}