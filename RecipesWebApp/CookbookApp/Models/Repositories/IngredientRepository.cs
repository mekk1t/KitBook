﻿using KK.Cookbook.Models.Database;
using KK.Cookbook.Models.Database.Entities;
using KK.Cookbook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KK.Cookbook.Models.Repositories
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
                .AsEnumerable();

            return ingredients;
        }

        public IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId)
        {
            throw new NotImplementedException();
        }

        public void RemoveIngredient(Guid ingredientId)
        {
            var ingredient = dbContext.Ingredients.FirstOrDefault(i => i.Id == ingredientId);
            dbContext.Ingredients.Remove(ingredient);
            dbContext.SaveChanges();
        }
    }
}
