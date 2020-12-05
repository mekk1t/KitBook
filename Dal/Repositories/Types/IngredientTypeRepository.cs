using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstractions;
using BusinessLogic.Models;
using DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class IngredientTypeRepository : IRepositoryAdvanced<IngredientType>
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

        public IngredientType GetByIdWithRelationships(Guid id)
        {
            return dbContext.IngredientTypes.AsNoTracking().Include(it => it.Icon).FirstOrDefault(it => it.Id == id);
        }

        public IEnumerable<IngredientType> GetListWithRelationships(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.IngredientTypes.AsNoTracking().Include(it => it.Icon).AsEnumerable();
        }
    }
}