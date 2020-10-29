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
    public class RecipeRepository : IRepository<Recipe>
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
                .Paged()
                .AsEnumerable();
        }

        public void Update(Recipe entity)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.Id == entity.Id);
            recipe = entity;
            dbContext.SaveChanges();
        }
    }
}
