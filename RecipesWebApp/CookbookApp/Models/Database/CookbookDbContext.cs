using Microsoft.EntityFrameworkCore;
using KK.Cookbook.Models.Database.Entities;
using System.Reflection;
using KK.Cookbook.Models.Database.Entities.Types;

namespace KK.Cookbook.Models.Database
{
    public class CookbookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<CookingType> CookingTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
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