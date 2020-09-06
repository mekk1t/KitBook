using KK.Cookbook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using KK.Cookbook.Models.Database;
using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KK.Cookbook.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CookbookDbContext dbContext;

        public CategoryRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Category> GetRecipeCategories(Guid recipeId)
        {
            var categories = dbContext.RecipeCategories
                .Where(rc => rc.RecipeId == recipeId)
                .Select(rc => rc.Category)
                .AsNoTracking()
                .AsEnumerable();

            return categories;
        }
    }
}
