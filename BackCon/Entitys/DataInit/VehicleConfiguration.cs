using Entitys.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.DataInit
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles", "Concesionario");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Brand).HasMaxLength(50).IsRequired();
            builder.Property(v => v.Model).HasMaxLength(50).IsRequired();
            builder.Property(v => v.FuelType).HasMaxLength(30).IsRequired();
            builder.Property(v => v.Color).HasMaxLength(20);
            builder.Property(v => v.SalePrice).HasColumnType("decimal(18,2)");
            builder.Property(v => v.Stock).HasDefaultValue(0);

            builder.HasData(
                new Vehicle { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2022, SalePrice = 85000000, FuelType = "Gasoline", Color = "Gray", Stock = 3 },
                new Vehicle { Id = 2, Brand = "Mazda", Model = "CX-30", Year = 2023, SalePrice = 120000000, FuelType = "Gasoline", Color = "Red", Stock = 2 },
                new Vehicle { Id = 3, Brand = "Renault", Model = "Duster", Year = 2021, SalePrice = 78000000, FuelType = "Diesel", Color = "White", Stock = 4 }
            );
        }
    }
}
