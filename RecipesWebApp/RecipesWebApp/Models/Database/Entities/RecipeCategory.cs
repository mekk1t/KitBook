using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RecipesWebApp.Models.Database.Entities
{
    public class RecipeCategory
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
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
}
