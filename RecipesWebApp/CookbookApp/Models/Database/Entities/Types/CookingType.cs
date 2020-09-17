using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.Database.Entities.Types
{
    public class CookingType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class CookingTypeConfiguration : IEntityTypeConfiguration<CookingType>
    {
        public void Configure(EntityTypeBuilder<CookingType> builder)
        {
            builder.HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}