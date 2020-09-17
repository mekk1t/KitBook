using KK.Cookbook.Models.Commands;
using KK.Cookbook.Models.Commands.Interfaces;
using KK.Cookbook.Models.Database;
using KK.Cookbook.Models.Database.Entities;
using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Mappers;
using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.Repositories;
using KK.Cookbook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        private const string SQL_CONNECTION_STRING = "Server=localhost;Database=CookbookDB;Trusted_Connection=True;";

        // Maybe change connection to config / options class.
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<CookbookDbContext>(
                o => o.UseSqlServer(SQL_CONNECTION_STRING));
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<RecipeDto, Recipe>, RecipeMapper>();
            services.AddScoped<IMapper<IEnumerable<Recipe>, IEnumerable<RecipeDto>>, RecipeMapper>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}