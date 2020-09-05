﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RecipesWebApp.Models.Database;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<CookbookDbContext>();
            context.Database.Migrate();
            return app;
        }
    }
}