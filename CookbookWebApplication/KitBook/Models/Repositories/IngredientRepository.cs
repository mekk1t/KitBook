using KitBook.Helpers.Extensions;
using KitBook.Models.Database;
using KitBook.Models.Database.Entities;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitBook.Models.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly CookbookDbContext dbContext;

        public IngredientRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddNewIngredient(Ingredient ingredient)
        {
            dbContext.Ingredients.Add(ingredient);
            dbContext.SaveChanges();
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            var ingredients = dbContext.Ingredients
                .AsNoTracking()
                .Paged()
                .AsEnumerable();

            return ingredients;
        }

        public IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId)
        {
            return dbContext.RecipeIngredients
                .Include(ri => ri.Ingredient)
                .AsNoTracking()
                .Where(ri => ri.RecipeId == recipeId)
                .Select(ri => ri.Ingredient)
                .Paged()
                .AsEnumerable();
        }

        public void RemoveIngredient(Guid ingredientId)
        {
            var ingredient = dbContext.Ingredients.FirstOrDefault(i => i.Id == ingredientId);
            dbContext.Ingredients.Remove(ingredient);
            dbContext.SaveChanges();
        }
    }
}
