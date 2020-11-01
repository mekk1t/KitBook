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
    public class RecipeRepositoryTests_TypesOperations : DatabaseTests
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

        private Recipe newRecipeWithoutTypes;
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

            newRecipeWithoutTypes = new Recipe
            {
                Id = Guid.NewGuid(),
                CookingTimeMinutes = 10,
                Title = "Some title",
                Description = "Some description",
                SourceURL = "www.testing.org"
            };

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

        public RecipeRepositoryTests_TypesOperations()
        {
            sut = new RecipeRepository(dbContext);
            recipeTypeRepository = new RecipeTypeRepository(dbContext);
            cookingTypeRepository = new CookingTypeRepository(dbContext);
            dishTypeRepository = new DishTypeRepository(dbContext);

            Init();

            EnsureTypesExistInTheDatabase();
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
            sut.Create(newRecipeWithTypesIds);

            var recipe = sut.ReadWithRelationships(newRecipeWithTypesIds.Id);
            recipe.HasTypes();
        }

        [Fact]
        public void Repository_creates_a_new_recipe_with_the_types_as_objects_passed_in()
        {
            sut.Create(newRecipeWithTypesEntities);

            var recipe = sut.Read(newRecipeWithTypesEntities.Id);
            recipe.HasTypesIds();
        }

        [Fact]
        public void Repository_does_not_create_a_record_with_the_same_primary_key()
        {
            sut.Create(newRecipeWithTypesEntities);

            Action act = () => sut.Create(newRecipeWithTypesEntities);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Repository_updates_a_record_in_the_database_via_reference()
        {
            sut.Create(newRecipeWithTypesEntities);
            var oldRecipe = sut.Read(newRecipeWithTypesEntities.Id);
            var editRecipe = oldRecipe.Copy();
            editRecipe.SourceURL = "www.newsite.ru";
            editRecipe.Description = "Sample text textovichh";
            editRecipe.Title = "TESTING RECIPE";

            sut.Update(editRecipe);

            sut.Read(newRecipeWithTypesEntities.Id).Should().NotBeEquivalentTo(oldRecipe);
        }

        [Fact]
        public void Repository_gets_a_record_by_id_from_the_database()
        {
            sut.Create(newRecipeWithTypesEntities);

            var result = sut.Read(newRecipeWithTypesEntities.Id);

            result.Should().NotBeNull();
        }

        [Fact]
        public void Repository_creates_a_new_recipe_without_types()
        {
            sut.Create(newRecipeWithoutTypes);

            sut.ReadWithRelationships(newRecipeWithoutTypes.Id).HasNoTypes();
        }

        [Fact]
        public void Repository_deletes_a_recipe_by_id_leaving_types_intact()
        {
            sut.Create(newRecipeWithTypesIds);

            sut.Delete(newRecipeWithTypesIds.Id);

            sut.Read(newRecipeWithTypesIds.Id).Should().BeNull();
            TypesRemainInTheDatabase();
        }
    }
}
