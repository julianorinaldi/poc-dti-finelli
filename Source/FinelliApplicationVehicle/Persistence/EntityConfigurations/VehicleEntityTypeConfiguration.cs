using FinelliDomainVehicle;
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

            builder.HasKey(o => o.Id);

            builder
                .Property<String>(nameof(Vehicle.Chassi))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Chassi))
                .IsRequired();

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
                .Property<string>(nameof(Vehicle.Description))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Description));

            builder
                .Property<string>(nameof(Vehicle.Color))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Vehicle.Color));
        }
    }
}