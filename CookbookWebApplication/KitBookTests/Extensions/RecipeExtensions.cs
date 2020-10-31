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
            recipe.CookingTypeId.Should().NotBeEmpty();
        }
    }
}
