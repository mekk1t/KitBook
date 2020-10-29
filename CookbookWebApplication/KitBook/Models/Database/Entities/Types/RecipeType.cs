using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KitBook.Models.Database.Entities.Types
{
    public class RecipeType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class RecipeTypeConfiguration : IEntityTypeConfiguration<RecipeType>
    {
        public void Configure(EntityTypeBuilder<RecipeType> builder)
        {
            builder.HasIndex(rt => rt.Name)
                .IsUnique();
        }
    }
}
