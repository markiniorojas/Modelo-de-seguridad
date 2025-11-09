using Entitys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Context
{
    // Cambia el nombre del namespace para evitar conflicto con Microsoft.EntityFrameworkCore.DbContext
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Seller> Vendedores { get; set; }
        public DbSet<Sale> Ventas { get; set; }
        public DbSet<SaleDetails> DetalleVentas { get; set; }
        public DbSet<Supplier> Proveedores { get; set; }
        public DbSet<VehicleSupplier> VehiculoProveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional si es necesario
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
