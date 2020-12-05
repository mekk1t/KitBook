using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Gets <see cref="DbContext"/> instance of type <typeparamref name="T"/> from DI container and applies all pending migrations.
        /// </summary>
        public static IApplicationBuilder ApplyDatabaseMigrations<T>(this IApplicationBuilder app)
            where T: DbContext, IDisposable
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<T>();
            context.Database.Migrate();
            return app;
        }
    }
}