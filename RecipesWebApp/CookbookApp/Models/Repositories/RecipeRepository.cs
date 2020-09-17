using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Repositories.Filters;
using KK.Cookbook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using KK.Cookbook.Models.Database;
using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KK.Cookbook.Models.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private const int PAGE_SIZE = 20;
        private readonly CookbookDbContext dbContext;

        public RecipeRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddCommentToRecipe(Guid recipeId, Comment newComment)
        {
            var dbRecipe = dbContext.Recipes
                .Include(r => r.Comments)
                .FirstOrDefault(r => r.Id == recipeId);
            dbRecipe.Comments.Add(newComment);
            dbContext.SaveChanges();
        }

        public void AddIngredientToRecipe(Guid recipeId, Guid ingredientId)
        {
            dbContext.RecipeIngredients.Add(new RecipeIngredient
            {
                RecipeId = recipeId,
                IngredientId = ingredientId
            });
            dbContext.SaveChanges();
        }

        public void AddNewRecipe(Recipe newRecipe)
        {
            dbContext.Recipes.Add(newRecipe);
            dbContext.SaveChanges();
        }

        public void EditCommentToRecipe(Guid commentId, string newCommentText)
        {
            var recipeComments = dbContext.Recipes.Select(r => r.Comments.FirstOrDefault(c => c.Id == commentId));
            var comment = recipeComments.First();
            comment.Text = newCommentText;

            dbContext.SaveChanges();
        }

        public void EditRecipeById(Guid recipeId, Recipe editRecipe)
        {
            var recipe = dbContext.Recipes.FirstOrDefault(r => r.Id == recipeId);
            // TODO implement update

            dbContext.Update(recipe);
            dbContext.SaveChanges();
        }

        public void EditRecipeIngredientInfo(Guid recipeId, Guid ingredientId, RecipeIngredientInfo info)
        {
            var recipeIngredient = dbContext.RecipeIngredients.FirstOrDefault(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);
            recipeIngredient.G = info.G;
            recipeIngredient.Ml = info.Ml;
            recipeIngredient.Amount = info.Amount;
            recipeIngredient.IsOptional = (bool)info.IsOptional;
            dbContext.SaveChanges();
        }

        public Recipe GetRecipeById(Guid recipeId)
        {
            return dbContext.Recipes
                .AsNoTracking()
                .FirstOrDefault(r => r.Id == recipeId);
        }

        public IEnumerable<Recipe> GetRecipes(int pageNumber = 1)
        {
            return dbContext.Recipes
                .AsNoTracking()
                .Include(r => r.RecipeType)
                .Include(r => r.CookingType)
                .Include(r => r.DishType)
                .Include(r => r.Ingredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Skip((pageNumber - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .AsEnumerable();
        }

        public IEnumerable<Recipe> GetRecipesByIngredients(List<Guid> ingredientIds)
        {
            var IDs = dbContext.RecipeIngredients
                .AsNoTracking()
                .Select(ri => new { ri.IngredientId, ri.RecipeId })
                .ToList();

            for (int i = 0; i < ingredientIds.Count; i++)
            {
                // TODO: отфильтровать айдишники по входящим гуидам, и выбрать RecipeIds в новую коллекцию. Потом по этим айдишникам выцепить сущности.
            }

            return null;
        }

        public IEnumerable<Recipe> GetRecipesFiltered(RecipeFilter filter)
        {
            throw new NotImplementedException();
        }

        public void RemoveCommentFromRecipe(Guid commentId)
        {
            var comment = dbContext.Recipes
                .Include(r => r.Comments)
                .Select(r => r.Comments.FirstOrDefault(c => c.Id == commentId))
                .FirstOrDefault();

            dbContext.Comments.Remove(comment);
            dbContext.SaveChanges();
        }

        public void RemoveIngredientFromRecipe(Guid recipeId, Guid ingredientId)
        {
            dbContext.RecipeIngredients.Remove(new RecipeIngredient
            {
                RecipeId = recipeId,
                IngredientId = ingredientId
            });
            dbContext.SaveChanges();
        }

        public IEnumerable<Recipe> SearchRecipesByName_ExactMatch(string searchText)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> SearchRecipesByName_Occurrences(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
