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
    public class RecipeRepository : IRepositoryAdvanced<Recipe>
    {
        private readonly CookbookDbContext dbContext;

        public RecipeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Recipe entity)
        {
            dbContext.Recipes.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.Id == id);
            dbContext.Recipes.Remove(recipe);
            dbContext.SaveChanges();
        }

        public Recipe Read(Guid id)
        {
            return dbContext.Recipes
                .AsNoTracking()
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> Read()
        {
            return dbContext.Recipes
                .AsNoTracking()
                .AsEnumerable();
        }

        public Recipe ReadWithRelationships(Guid id)
        {
            // TODO: implement Ingredients include.
            return dbContext.Recipes
                .AsNoTracking()
                .Include(r => r.CookingType)
                .Include(r => r.DishType)
                .Include(r => r.RecipeType)
                .Include(r => r.Stages)
                .Include(r => r.Comments)
                .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> ReadWithRelationships()
        {
            // TODO: implement Ingredients include.
            return dbContext.Recipes
                .AsNoTracking()
                .Include(r => r.CookingType)
                .Include(r => r.DishType)
                .Include(r => r.RecipeType)
                .Include(r => r.Stages)
                .AsEnumerable();
        }

        public void Update(Recipe entity)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.Id == entity.Id);
            recipe.UpdateOptionalFields(entity);
            recipe.UpdateTypesById(entity);
            dbContext.SaveChanges();
        }
    }
}
