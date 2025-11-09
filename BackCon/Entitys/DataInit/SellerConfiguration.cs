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
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Vendedores", schema: "Concesionario");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(v => v.Email).HasMaxLength(100).IsRequired();
            builder.Property(v => v.Phone).HasMaxLength(15);
            builder.Property(v => v.Commission).HasColumnType("decimal(5,2)");

            builder.HasData(
                new Seller { Id = 1, FirstName = "María López", Email = "maria@concesionario.com", Phone = "3114448899", Commission = 10 },
                new Seller { Id = 2, FirstName = "Juan Torres", Email = "juan@concesionario.com", Phone = "3145559988", Commission = 12 }
            );
        }
    }
   
}
