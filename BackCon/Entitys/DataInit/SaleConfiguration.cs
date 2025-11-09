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
    public class SaleConfiguration : IEntityTypeConfiguration<Models.Sale>
    {
        public void Configure(EntityTypeBuilder<Models.Sale> builder)
        {
            builder.ToTable("Ventas", schema: "Concesionario");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Total).HasColumnType("decimal(18,2)");

            builder.HasOne(v => v.Client)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(v => v.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Seller)
                   .WithMany(ve => ve.Sales)
                   .HasForeignKey(v => v.Seller)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Models.Sale { Id = 1, SaleDate = DateTime.Parse("2024-04-01"), Total = 85000000, ClientId = 1, SellerId = 1 },
                new Models.Sale { Id = 2, SaleDate = DateTime.Parse("2024-04-05"), Total = 120000000, ClientId = 2, SellerId = 2 }
            );
        }
    }
}
