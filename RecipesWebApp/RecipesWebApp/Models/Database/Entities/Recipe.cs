using mekk1t.Cookbook.Models.Database.Entities.Custom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesWebApp.Models.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesWebApp.Models.Database.Entities
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan CookingTime { get; set; }
        public CookingType CookingType { get; set; }
        public RecipeType RecipeType { get; set; }
        public DishType DishType { get; set; }
        public string SourceURL { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }
        public List<RecipeCategory> Categories { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Stage> Stages { get; set; }
        public Image Image { get; set; }
    }

    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(r => r.CookingType)
                .HasConversion<string>();

            builder.Property(r => r.RecipeType)
                .HasConversion<string>();

            builder.Property(r => r.DishType)
                .HasConversion<string>();
        }
    }
}