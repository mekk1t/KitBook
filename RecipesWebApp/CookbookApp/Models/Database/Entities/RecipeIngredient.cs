using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KK.Cookbook.Models.Database.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int? Amount { get; set; }
        public int? G { get; set; }
        public int? Ml { get; set; }
        public bool IsOptional { get; set; }
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
}