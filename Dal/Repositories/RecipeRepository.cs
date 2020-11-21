using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities;
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

        public void DeleteById(Guid id)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.Id == id);
            dbContext.Recipes.Remove(recipe);
            dbContext.SaveChanges();
        }

        public Recipe GetById(Guid id)
        {
            return dbContext.Recipes
                .AsNoTracking()
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> GetList(int pageSize = 10, int pageNumber = 1)
        {
            return dbContext.Recipes
                .AsNoTracking()
                .AsEnumerable();
        }

        public Recipe GetByIdWithRelationships(Guid id)
        {
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

        public IEnumerable<Recipe> GetListWithRelationships(int pageSize = 10, int pageNumber = 1)
        {
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
            var recipe = dbContext.Recipes
                .FirstOrDefault(r => r.Id == entity.Id);
            recipe.Title = entity.Title;
            recipe.Description = entity.Description;
            recipe.SourceURL = entity.SourceURL;
            recipe.CookingTimeMinutes = entity.CookingTimeMinutes;
            recipe.CookingTypeId = entity.CookingTypeId;
            recipe.DishTypeId = entity.DishTypeId;
            recipe.RecipeTypeId = entity.RecipeTypeId;
            if (entity.Thumbnail != null)
            {
                recipe.Thumbnail = entity.Thumbnail;
            }

            if (entity.Stages?.Count() > 0)
            {
                var stages = dbContext.Stages.AsNoTracking().Where(s => s.RecipeId == entity.Id);
                dbContext.Stages.RemoveRange(stages);
                dbContext.Stages.AddRange(entity.Stages);
            }

            if (entity.Ingredients?.Count() > 0)
            {
                var recipeIngredients = dbContext.RecipeIngredients.AsNoTracking().Where(s => s.RecipeId == entity.Id);
                dbContext.RecipeIngredients.RemoveRange(recipeIngredients);
                dbContext.RecipeIngredients.AddRange(entity.Ingredients);
            }
            dbContext.SaveChanges();
        }
    }
}
