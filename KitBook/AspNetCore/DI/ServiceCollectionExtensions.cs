using BusinessLogic.Abstractions;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DAL.Database;
using DAL.Repositories;
using KitBook.Mappers;
using KitBook.Models.Repositories;
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
                .AddScoped<IRepositoryAdvanced<Recipe>, RecipeRepository>()
                .AddScoped<IRepositoryAdvanced<Ingredient>, IngredientRepository>()
                .AddScoped<IRepositoryAdvanced<RecipeType>, RecipeTypeRepository>()
                .AddScoped<IRepositoryAdvanced<CookingType>, CookingTypeRepository>()
                .AddScoped<IRepositoryAdvanced<CookingType>, CookingTypeRepository>()
                .AddScoped<IRepositoryAdvanced<DishType>, DishTypeRepository>()
                .AddScoped<IRepositoryAdvanced<IngredientType>, IngredientTypeRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IRecipeService, RecipeService>()
                .AddScoped<IIngredientService, IngredientService>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
                .AddScoped<ITypeMapper, TypeMapper>()
                .AddScoped<IRecipeMapper, RecipeMapper>()
                .AddScoped<IIngredientMapper, IngredientMapper>()
                .AddScoped<IStageMapper, StageMapper>();

            return services;
        }
    }
}