using FluentAssertions;
using KitBook.Models.Database.Entities;
using KitBook.Models.Database.Entities.Types;

namespace KitBookTests.Extensions
{
    public static class TypesExtensions
    {
        public static void RemainsInTheDatabase(this RecipeType recipeType)
        {
            recipeType.Should().NotBeNull();
        }

        public static void RemainsInTheDatabase(this CookingType cookingType)
        {
            cookingType.Should().NotBeNull();
        }

        public static void RemainsInTheDatabase(this DishType dishType)
        {
            dishType.Should().NotBeNull();
        }

        public static void RemainsInTheDatabase(this Recipe recipe)
        {
            recipe.Should().NotBeNull();
        }
    }
}