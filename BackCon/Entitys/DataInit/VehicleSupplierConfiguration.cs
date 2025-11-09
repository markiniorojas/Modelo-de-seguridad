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
    public class VehicleSupplierConfiguration : IEntityTypeConfiguration<VehicleSupplier>
    {
        public void Configure(EntityTypeBuilder<VehicleSupplier> builder)
        {
            builder.ToTable("VehicleSuppliers", schema: "Concesionario");
            builder.HasKey(vp => vp.Id);

            builder.Property(vp => vp.PurchasePrice).HasColumnType("decimal(18,2)");

            builder.HasOne(vp => vp.Vehicle)
                   .WithMany(v => v.VehicleSuppliers)
                   .HasForeignKey(vp => vp.VehicleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(vp => vp.Supplier)
                   .WithMany(p => p.VehicleSuppliers)
                   .HasForeignKey(vp => vp.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new VehicleSupplier { Id = 1, VehicleId = 1, SupplierId = 1, PurchasePrice = 72000000, PurchaseDate = DateTime.Parse("2024-01-10") },
                new VehicleSupplier { Id = 2, VehicleId = 2, SupplierId = 2, PurchasePrice = 95000000, PurchaseDate = DateTime.Parse("2024-02-05") },
                new VehicleSupplier { Id = 3, VehicleId = 3, SupplierId = 1, PurchasePrice = 65000000, PurchaseDate = DateTime.Parse("2024-03-18") }
            );
        }
    }
}
