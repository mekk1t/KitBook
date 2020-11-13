using KitBook.Models.Database.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace KitBook.Models.Database.Entities
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSugary{ get; set; }
        public bool IsSour { get; set; }
        public ICollection<RecipeIngredient> Recipes { get; set; }
        public Guid IngredientTypeId { get; set; }
        public IngredientType Type { get; set; }
    }

    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasIndex(i => i.Name)
                .IsUnique();
        }
    }
}