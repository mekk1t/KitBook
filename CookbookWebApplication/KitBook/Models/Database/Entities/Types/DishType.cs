using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace KitBook.Models.Database.Entities.Types
{
    public class DishType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DishTypeConfiguration : IEntityTypeConfiguration<DishType>
    {
        public void Configure(EntityTypeBuilder<DishType> builder)
        {
            builder.HasIndex(d => d.Name)
                .IsUnique();
        }
    }
}
