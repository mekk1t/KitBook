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
    }
}
