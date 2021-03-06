using DAL.Database;
using KitBook.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KitBook
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDatabase();
            services.AddRepositories();
            services.AddServices();
            services.AddMappers();
            services.AddScoped<IFileHandler<IFormFile>, FormFileHandler>();
            services.AddScoped<ITypeHandler, TypeHandler>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ApplyDatabaseMigrations<CookbookDbContext>();
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
