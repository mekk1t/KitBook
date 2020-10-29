using KitBook.Models.Database;
using KitBook.Models.Database.Entities;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories;
using KitBook.Models.Repositories.Interfaces;
using KitBook.Models.Repositories.Types;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private const string SQL_CONNECTION_STRING = "Server=localhost;Database=CookbookDB;Trusted_Connection=True;";

        // Maybe change connection to config / options class.
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<CookbookDbContext>(
                o => o.UseSqlServer(SQL_CONNECTION_STRING));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IRepository<Recipe>, RecipeRepository>()
                .AddScoped<IRepository<Ingredient>, IngredientRepository>()
                .AddScoped<IRepository<RecipeType>, RecipeTypeRepository>()
                .AddScoped<IRepository<CookingType>, CookingTypeRepository>()
                .AddScoped<IRepository<DishType>, DishTypeRepository>()
                .AddScoped<IRepository<IngredientType>, IngredientTypeRepository>();

            return services;
        }
    }
}