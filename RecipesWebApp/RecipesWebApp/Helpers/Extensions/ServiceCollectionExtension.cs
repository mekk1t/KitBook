using Microsoft.EntityFrameworkCore;
using RecipesWebApp.Models.Database;

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
    }
}