using FinelliDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FinelliApplication.Persistence.EntityConfigurations
{
    internal class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle));

            builder.HasKey(o => o.Chassi);

            builder.HasAlternateKey(o => o.Chassi);

            builder
                .Property<String>(nameof(Vehicle.VehicleName))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.VehicleName))
                .IsRequired();
        }
    }
}