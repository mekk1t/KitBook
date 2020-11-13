using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using KitBook.Models.Database.Entities;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories;
using KitBook.Models.Repositories.Interfaces;
using KitBookTests.Repositories.Base;
using Xunit;

namespace KitBookTests.Repositories
{
    public class RecipeRepositoryTests_IngredientsOperations : DatabaseTests
    {
        private Ingredient ingredient1;
        private Ingredient ingredient2;
        private readonly Guid INGREDIENT1_ID = Guid.NewGuid();
        private readonly Guid INGREDIENT2_ID = Guid.NewGuid();

        private IngredientType type;
        private readonly Guid INGREDIENT_TYPE_ID = Guid.NewGuid();

        private Recipe recipe;
        private readonly Guid RECIPE_ID = Guid.NewGuid();

        private IRepositoryAdvanced<Recipe> sut;

        public RecipeRepositoryTests_IngredientsOperations()
        {
            sut = new RecipeRepository(dbContext);

            InitializeEntities();
            EnsureIngredientsExistInTheDatabase();
        }

        [Fact]
        public void Adding_an_entity_with_existing_recipeIngredient_ids_creates_a_many_to_many_relationship()
        {
            sut.Create(recipe);

            var result = sut.ReadWithRelationships(RECIPE_ID).Ingredients;

            result.Count().Should().Be(recipe.Ingredients.Count());
        }

        private void InitializeEntities()
        {
            ingredient1 = new Ingredient
            {
                Id = INGREDIENT1_ID,
                IngredientTypeId = INGREDIENT_TYPE_ID,
                Name = "Ingredient 1"
            };
            ingredient2 = new Ingredient
            {
                Id = INGREDIENT2_ID,
                IngredientTypeId = INGREDIENT_TYPE_ID,
                Name = "Ingredient 2"
            };
            type = new IngredientType
            {
                Id = INGREDIENT_TYPE_ID,
                Name = "Type"
            };
            recipe = new Recipe
            {
                Id = RECIPE_ID,
                CookingTimeMinutes = 5,
                Description = "Something",
                SourceURL = "www.text.org",
                Title = "Recipe",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient
                    {
                        IngredientId = INGREDIENT1_ID,
                        RecipeId = RECIPE_ID
                    },
                    new RecipeIngredient
                    {
                        IngredientId = INGREDIENT2_ID,
                        RecipeId = RECIPE_ID
                    }
                }
            };
        }

        private void EnsureIngredientsExistInTheDatabase()
        {
            dbContext.IngredientTypes.Add(type);
            dbContext.Ingredients.Add(ingredient1);
            dbContext.Ingredients.Add(ingredient2);
        }
    }
}
