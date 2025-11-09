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
    public class SaleDetailsConfiguration : IEntityTypeConfiguration<SaleDetails>
    {
        public void Configure(EntityTypeBuilder<SaleDetails> builder)
        {
            builder.ToTable("SaleDetails", schema: "Concesionario");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(d => d.Subtotal).HasColumnType("decimal(18,2)");

            builder.HasOne(d => d.Sale)
                   .WithMany(v => v.SaleDetails)
                   .HasForeignKey(d => d.SaleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Vehicle)
                   .WithMany(v => v.SaleDetails)
                   .HasForeignKey(d => d.VehicleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new SaleDetails { Id = 1, SaleId = 1, VehicleId = 1, Quantity = 1, UnitPrice = 85000000, Subtotal = 85000000 },
                new SaleDetails { Id = 2, SaleId = 2, VehicleId = 2, Quantity = 1, UnitPrice = 120000000, Subtotal = 120000000 }
            );
        }
    }
}
