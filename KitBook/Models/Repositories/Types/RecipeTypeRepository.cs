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
    public class RecipeTypeRepository : IRepository<RecipeType>
    {
        private readonly CookbookDbContext dbContext;

        public RecipeTypeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(RecipeType entity)
        {
            dbContext.RecipeTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var type = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == id);
            dbContext.DishTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public RecipeType Read(Guid id)
        {
            return dbContext.RecipeTypes.AsNoTracking().FirstOrDefault(rt => rt.Id == id);
        }

        public IEnumerable<RecipeType> Read()
        {
            return dbContext.RecipeTypes.AsNoTracking().Paged().AsEnumerable();
        }

        public void Update(RecipeType entity)
        {
            var recipeType = dbContext.RecipeTypes.FirstOrDefault(rt => rt.Id == entity.Id);
            recipeType = entity;
            dbContext.SaveChanges();
        }
    }
}