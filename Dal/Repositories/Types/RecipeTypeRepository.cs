using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstractions;
using BusinessLogic.Models;
using DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RecipeTypeRepository : IRepositoryAdvanced<RecipeType>
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

        public void DeleteById(Guid id)
        {
            var type = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == id);
            dbContext.DishTypes.Remove(type);
            dbContext.SaveChanges();
        }

        public RecipeType GetById(Guid id)
        {
            return dbContext.RecipeTypes.AsNoTracking().FirstOrDefault(rt => rt.Id == id);
        }

        public RecipeType GetByIdWithRelationships(Guid id)
        {
            return dbContext.RecipeTypes.AsNoTracking().Include(rt => rt.Icon).FirstOrDefault(rt => rt.Id == id);
        }

        public IEnumerable<RecipeType> GetList(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.RecipeTypes.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<RecipeType> GetListWithRelationships(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.RecipeTypes.AsNoTracking().Include(rt => rt.Icon).AsEnumerable();
        }

        public void Update(RecipeType entity)
        {
            var recipeType = dbContext.RecipeTypes.FirstOrDefault(rt => rt.Id == entity.Id);
            recipeType.Name = entity.Name;
            if (entity.Icon != null)
            {
                var file = dbContext.Files.AsNoTracking().FirstOrDefault(f => f.Content == entity.Icon.Content);
                if (file == null)
                {
                    recipeType.Icon = entity.Icon;
                }
                else
                {
                    recipeType.Icon = file;
                }
            }
            dbContext.SaveChanges();
        }
    }
}