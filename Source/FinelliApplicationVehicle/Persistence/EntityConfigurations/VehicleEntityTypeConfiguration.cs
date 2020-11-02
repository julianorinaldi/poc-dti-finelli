using FinelliDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FinelliApplicationVehicle.Persistence.EntityConfigurations
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

            builder
                .Property<int>(nameof(Vehicle.Capacity))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Capacity))
                .IsRequired();

            builder
                .Property<int>(nameof(Vehicle.Year))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Year))
                .IsRequired();

            builder
                .Property<int>(nameof(Vehicle.Brand))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Brand))
                .IsRequired();

            builder
                .Property<String>(nameof(Vehicle.Color))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Color));
        }
    }
}