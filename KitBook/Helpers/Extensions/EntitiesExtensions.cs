using KitBook.Models.Database.Entities;

namespace KitBook.Helpers.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateOptionalFields(this Recipe recipe, Recipe edit)
        {
            recipe.CookingTimeMinutes = edit.CookingTimeMinutes;
            recipe.Description = edit.Description;
            recipe.Title = edit.Title;
            recipe.SourceURL = edit.SourceURL;
        }

        public static void UpdateTypesById(this Recipe recipe, Recipe edit)
        {
            recipe.CookingTypeId = edit.CookingTypeId;
            recipe.DishTypeId = edit.DishTypeId;
            recipe.RecipeTypeId = edit.RecipeTypeId;
        }

        public static void Update(this Ingredient ingredient, Ingredient edit)
        {
            ingredient.Name = edit.Name;
            ingredient.IsSour = edit.IsSour;
            ingredient.IsSpicy = edit.IsSpicy;
            ingredient.IsSugary = edit.IsSugary;
            ingredient.IngredientTypeId = edit.IngredientTypeId;
        }
    }
}
