using FinelliDomainMonolito;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FinelliApplicationMonolito.Persistence.EntityConfigurations
{
    internal class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable(nameof(Brand));

            builder.HasKey(o => o.Id);

            builder
                .Property<String>(nameof(Brand.Name))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Brand.Name))
                .IsRequired();

            builder
               .Property<String>(nameof(Brand.Decription))
               .UsePropertyAccessMode(PropertyAccessMode.Property)
               .HasColumnName(nameof(Brand.Decription));
        }
    }
}