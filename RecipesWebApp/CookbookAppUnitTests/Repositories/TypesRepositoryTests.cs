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

            cookingType = new CookingType
            {
                Id = Guid.NewGuid(),
                Name = SAMPLE_TEXT
            };

            dishType = new DishType
            {
                Id = Guid.NewGuid(),
                Name = SAMPLE_TEXT
            };

            recipeType = new RecipeType
            {
                Id = Guid.NewGuid(),
                Name = SAMPLE_TEXT
            };

            ingredientType = new IngredientType
            {
                Id = Guid.NewGuid(),
                Name = SAMPLE_TEXT
            };

            dbContext.Database.EnsureCreated();
        }

        [Test]
        public void Creating_a_new_recipe_type()
        {
            dbContext.RecipeTypes.Add(recipeType);
            var expected = dbContext.RecipeTypes.FirstOrDefault(rt => rt.Name == recipeType.Name);

            Assert.IsNotNull(expected);
        }

        [TearDown]
        public void Database_Cleanup()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
