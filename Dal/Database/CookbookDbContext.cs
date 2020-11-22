using Microsoft.EntityFrameworkCore;
using KitBook.Models.Database.Entities;
using System.Reflection;
using KitBook.Models.Database.Entities.Types;
using BusinessLogic.Models.Files;

namespace KitBook.Models.Database
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }

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