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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients", schema: "Concesionario");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Document).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(15);
            builder.Property(c => c.Email).HasMaxLength(100);

            builder.HasData(
                new Client { Id = 1, FirstName = "Carlos", LastName = "Garcia", Document = "10101010", Phone = "3101234567", Email = "carlos@gmail.com" },
                new Client { Id = 2, FirstName = "Ana", LastName = "Perez", Document = "20202020", Phone = "3209876543", Email = "ana@hotmail.com" }
            );
        }
    }
}
