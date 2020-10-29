using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KitBook.Models.Database.Entities.Types
{
    public class IngredientType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class IngredientTypeConfiguration : IEntityTypeConfiguration<IngredientType>
    {
        public void Configure(EntityTypeBuilder<IngredientType> builder)
        {
            builder.HasIndex(i => i.Name)
                .IsUnique();
        }
    }
}
