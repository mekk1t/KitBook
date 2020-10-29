using KitBook.Models.Database;
using KitBook.Models.Mappers;
using KitBook.Models.Mappers.Interfaces;
using KitBook.Models.Repositories;
using KitBook.Models.Repositories.Interfaces;
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

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
                .AddScoped<IRecipeMapper, RecipeMapper>()
                .AddScoped<ICommentMapper, CommentMapper>()
                .AddScoped<IStageMapper, StageMapper>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}