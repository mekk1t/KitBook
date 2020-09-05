using mekk1t.Cookbook.Models.Database.Entities.Custom;
using Microsoft.EntityFrameworkCore;
using RecipesWebApp.Models.Database.Entities;
using System.Reflection;

namespace RecipesWebApp.Models.Database
{
    public class CookbookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public CookbookDbContext(DbContextOptions<CookbookDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}