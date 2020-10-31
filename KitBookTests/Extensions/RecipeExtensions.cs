using FluentAssertions;
using KitBook.Models.Database.Entities;

namespace KitBookTests.Extensions
{
    public static class RecipeExtensions
    {
        public static void HasTypes(this Recipe recipe)
        {
            recipe.RecipeType.Should().NotBeNull();
            recipe.CookingType.Should().NotBeNull();
            recipe.DishType.Should().NotBeNull();
        }

        public static void HasTypesIds(this Recipe recipe)
        {
            recipe.CookingTypeId.Should().NotBeEmpty();
            recipe.DishTypeId.Should().NotBeEmpty();
            recipe.RecipeTypeId.Should().NotBeEmpty();
        }

        public static void HasNoTypes(this Recipe recipe)
        {
            recipe.CookingTypeId.Should().BeNull();
            recipe.DishTypeId.Should().BeNull();
            recipe.RecipeTypeId.Should().BeNull();
            recipe.CookingType.Should().BeNull();
            recipe.RecipeType.Should().BeNull();
            recipe.DishType.Should().BeNull();
        }

        public static Recipe Copy(this Recipe recipe)
        {
            return new Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                CookingTimeMinutes = recipe.CookingTimeMinutes,
                SourceURL = recipe.SourceURL
            };
        }
    }
}
