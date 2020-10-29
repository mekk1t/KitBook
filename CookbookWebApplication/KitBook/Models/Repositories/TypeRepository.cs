using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitBook.Helpers.Extensions;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitBook.Models.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly CookbookDbContext dbContext;

        public TypeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(RecipeType entity)
        {
            dbContext.RecipeTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Create(CookingType entity)
        {
            dbContext.CookingTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Create(IngredientType entity)
        {
            dbContext.IngredientTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Create(DishType entity)
        {
            dbContext.DishTypes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            // ???
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

        public void Update(CookingType entity)
        {
            var cookingType = dbContext.CookingTypes.FirstOrDefault(ct => ct.Id == entity.Id);
            cookingType = entity;
            dbContext.SaveChanges();
        }

        public void Update(IngredientType entity)
        {
            var ingredientType = dbContext.IngredientTypes.FirstOrDefault(it => it.Id == entity.Id);
            ingredientType = entity;
            dbContext.SaveChanges();
        }

        public void Update(DishType entity)
        {
            var dishType = dbContext.DishTypes.FirstOrDefault(dt => dt.Id == entity.Id);
            dishType = entity;
            dbContext.SaveChanges();
        }

        CookingType IRepository<CookingType>.Read(Guid id)
        {
            return dbContext.CookingTypes.AsNoTracking().FirstOrDefault(ct => ct.Id == id);
        }

        IEnumerable<CookingType> IRepository<CookingType>.Read()
        {
            return dbContext.CookingTypes.AsNoTracking().Paged().AsEnumerable();
        }

        IngredientType IRepository<IngredientType>.Read(Guid id)
        {
            return dbContext.IngredientTypes.AsNoTracking().FirstOrDefault(it => it.Id == id);
        }

        IEnumerable<IngredientType> IRepository<IngredientType>.Read()
        {
            return dbContext.IngredientTypes.AsNoTracking().Paged().AsEnumerable();
        }

        DishType IRepository<DishType>.Read(Guid id)
        {
            return dbContext.DishTypes.AsNoTracking().FirstOrDefault(dt => dt.Id == id);
        }

        IEnumerable<DishType> IRepository<DishType>.Read()
        {
            return dbContext.DishTypes.AsNoTracking().Paged().AsEnumerable();
        }
    }
}
