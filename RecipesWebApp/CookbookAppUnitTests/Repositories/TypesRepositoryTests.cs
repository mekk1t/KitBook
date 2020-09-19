using KK.Cookbook.Models.Database;
using KK.Cookbook.Models.Database.Entities.Types;
using KK.Cookbook.Models.Repositories;
using KK.Cookbook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookAppUnitTests.Repositories
{
    public class TypesRepositoryTests
    {
        private ITypeRepository repository;
        private CookbookDbContext dbContext;

        private CookingType cookingType;
        private DishType dishType;
        private IngredientType ingredientType;
        private RecipeType recipeType;

        private const string SAMPLE_TEXT = "Sample text";

        [SetUp]
        public void Initial_Settings()
        {
            var dbOptions = new DbContextOptionsBuilder<CookbookDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            dbContext = new CookbookDbContext(dbOptions);
            repository = new TypesRepository(dbContext);

            dbContext.Database.EnsureCreated();
        }

        [Test]
        public void Creating_a_new_recipe_type()
        {
            repository.AddNewRecipeType(SAMPLE_TEXT);
            var expected = dbContext.RecipeTypes.FirstOrDefault(rt => rt.Name == SAMPLE_TEXT);

            Assert.IsNotNull(expected);
        }

        [Test]
        public void Creating_a_new_cooking_type()
        {
            repository.AddNewCookingType(SAMPLE_TEXT);
            var expected = dbContext.CookingTypes.FirstOrDefault(ct => ct.Name == SAMPLE_TEXT);

            Assert.IsNotNull(expected);
        }

        [Test]
        public void Creating_a_new_dish_type()
        {
            repository.AddNewDishType(SAMPLE_TEXT);
            var expected = dbContext.DishTypes.FirstOrDefault(ct => ct.Name == SAMPLE_TEXT);

            Assert.IsNotNull(expected);
        }

        [Test]
        public void Creating_a_new_ingredient_type()
        {
            repository.AddNewIngredientType(SAMPLE_TEXT);
            var expected = dbContext.IngredientTypes.FirstOrDefault(ct => ct.Name == SAMPLE_TEXT);

            Assert.IsNotNull(expected);
        }

        [TearDown]
        public void Database_Cleanup()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
