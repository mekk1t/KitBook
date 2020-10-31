using System;
using FluentAssertions;
using KitBook.Models.Database.Entities;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories;
using KitBook.Models.Repositories.Interfaces;
using KitBook.Models.Repositories.Types;
using KitBookTests.Extensions;
using KitBookTests.Repositories.Base;
using Xunit;

namespace KitBookTests.Repositories
{
    public class RecipeRepositoryTests : DatabaseTests
    {
        private readonly IRepositoryAdvanced<Recipe> sut;

        private readonly IRepository<RecipeType> recipeTypeRepository;
        private readonly IRepository<CookingType> cookingTypeRepository;
        private readonly IRepository<DishType> dishTypeRepository;

        private readonly Guid RECIPE_WITH_TYPES_IDS_ID = Guid.NewGuid();
        private readonly Guid RECIPE_WITH_TYPES_ENTITIES_ID = Guid.NewGuid();

        private readonly Guid RECIPE_TYPE_ID = Guid.NewGuid();
        private readonly Guid COOKING_TYPE_ID = Guid.NewGuid();
        private readonly Guid DISH_TYPE_ID = Guid.NewGuid();

        private CookingType cookingType;
        private DishType dishType;
        private RecipeType recipeType;

        private Recipe newRecipeWithTypesIds;
        private Recipe newRecipeWithTypesEntities;

        private void InitializeTypeModels()
        {
            cookingType = new CookingType
            {
                Id = COOKING_TYPE_ID,
                Name = "Cooking Type"
            };
            dishType = new DishType
            {
                Id = DISH_TYPE_ID,
                Name = "Dish Type"
            };
            recipeType = new RecipeType
            {
                Id = RECIPE_TYPE_ID,
                Name = "Recipe Type"
            };
        }

        private void Init()
        {
            InitializeTypeModels();

            newRecipeWithTypesIds = new Recipe
            {
                Id = RECIPE_WITH_TYPES_IDS_ID,
                RecipeTypeId = RECIPE_TYPE_ID,
                CookingTypeId = COOKING_TYPE_ID,
                DishTypeId = DISH_TYPE_ID,
                CookingTimeMinutes = 10,
                Description = "Sample text",
                Title = "Sample text",
                SourceURL = "www.sample.com"
            };

            newRecipeWithTypesEntities = new Recipe
            {
                Id = RECIPE_WITH_TYPES_ENTITIES_ID,
                RecipeType = recipeType,
                CookingType = cookingType,
                DishType = dishType,
                CookingTimeMinutes = 5,
                Description = "Mafaka",
                Title = "Text",
                SourceURL = "www.someurl.org"
            };
        }

        public RecipeRepositoryTests()
        {
            sut = new RecipeRepository(dbContext);
            recipeTypeRepository = new RecipeTypeRepository(dbContext);
            cookingTypeRepository = new CookingTypeRepository(dbContext);
            dishTypeRepository = new DishTypeRepository(dbContext);

            Init();
        }

        private void EnsureTypesExistInTheDatabase()
        {
            recipeTypeRepository.Create(recipeType);
            cookingTypeRepository.Create(cookingType);
            dishTypeRepository.Create(dishType);

            dbContext.SaveChanges();
        }

        private void TypesRemainInTheDatabase()
        {
            recipeTypeRepository.Read(RECIPE_TYPE_ID).RemainsInTheDatabase();
            cookingTypeRepository.Read(COOKING_TYPE_ID).RemainsInTheDatabase();
            dishTypeRepository.Read(DISH_TYPE_ID).RemainsInTheDatabase();
        }

        [Fact]
        public void Repository_creates_a_new_recipe_with_only_types_ids_passed_in()
        {
            EnsureTypesExistInTheDatabase();

            sut.Create(newRecipeWithTypesIds);

            var recipe = sut.ReadWithRelationships(newRecipeWithTypesIds.Id);
            recipe.HasTypes();
        }

        [Fact]
        public void Repository_creates_a_new_recipe_with_the_types_as_objects_passed_in()
        {
            EnsureTypesExistInTheDatabase();

            sut.Create(newRecipeWithTypesEntities);

            var recipe = sut.Read(newRecipeWithTypesEntities.Id);
            recipe.HasTypesIds();
        }

        [Fact]
        public void Repository_deletes_a_recipe_by_id_leaving_types_intact()
        {
            EnsureTypesExistInTheDatabase();
            sut.Create(newRecipeWithTypesIds);

            sut.Delete(newRecipeWithTypesIds.Id);

            sut.Read(newRecipeWithTypesIds.Id).Should().BeNull();
            TypesRemainInTheDatabase();
        }
    }
}
