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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", schema: "Concesionario");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Contact).HasMaxLength(50);
            builder.Property(p => p.Phone).HasMaxLength(15);
            builder.Property(p => p.Email).HasMaxLength(100);

            builder.HasData(
                new Supplier { Id = 1, CompanyName = "AutoImport S.A.", Contact = "Jorge", Phone = "3160001111", Email = "sales@autoimport.com" },
                new Supplier { Id = 2, CompanyName = "MotorHuila Ltda.", Contact = "Laura", Phone = "3171112222", Email = "info@motorhuila.com" }
            );
        }
    }
}
