using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database
{
    public class EntityConfiguration
    {
        public class CookingTypeConfiguration : IEntityTypeConfiguration<CookingType>
        {
            public void Configure(EntityTypeBuilder<CookingType> builder)
            {
                builder.HasIndex(r => r.Name)
                    .IsUnique();
            }
        }
        public class RecipeTypeConfiguration : IEntityTypeConfiguration<RecipeType>
        {
            public void Configure(EntityTypeBuilder<RecipeType> builder)
            {
                builder.HasIndex(rt => rt.Name)
                    .IsUnique();
            }
        }
        public class DishTypeConfiguration : IEntityTypeConfiguration<DishType>
        {
            public void Configure(EntityTypeBuilder<DishType> builder)
            {
                builder.HasIndex(d => d.Name)
                    .IsUnique();
            }
        }
        public class IngredientTypeConfiguration : IEntityTypeConfiguration<IngredientType>
        {
            public void Configure(EntityTypeBuilder<IngredientType> builder)
            {
                builder.HasIndex(i => i.Name)
                    .IsUnique();
            }
        }
        public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
        {
            public void Configure(EntityTypeBuilder<Ingredient> builder)
            {
                builder.HasIndex(i => i.Name)
                    .IsUnique();
            }
        }
        public class RecipeCategoryConfiguration : IEntityTypeConfiguration<RecipeCategory>
        {
            public void Configure(EntityTypeBuilder<RecipeCategory> builder)
            {
                builder.HasKey(rc => new { rc.RecipeId, rc.CategoryId });

                builder
                    .HasOne(rc => rc.Recipe)
                    .WithMany(r => r.Categories)
                    .HasForeignKey(r => r.RecipeId);

                builder
                    .HasOne(rc => rc.Category)
                    .WithMany(c => c.Recipes)
                    .HasForeignKey(c => c.CategoryId);
            }
        }
        public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
        {
            public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
            {
                builder.HasKey(rc => new { rc.RecipeId, rc.IngredientId });

                builder
                    .HasOne(rc => rc.Recipe)
                    .WithMany(r => r.Ingredients)
                    .HasForeignKey(r => r.RecipeId);

                builder
                    .HasOne(rc => rc.Ingredient)
                    .WithMany(c => c.Recipes)
                    .HasForeignKey(c => c.IngredientId);
            }
        }

        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasOne(u => u.Avatar)
                    .WithOne();
            }
        }
    }
}
