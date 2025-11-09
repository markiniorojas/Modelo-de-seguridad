using Entitys.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.DbContext.Factory
{
    public class PostgresDbContextFactory : IDbContextFactory
    {
        public ApplicationDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString,
                sql => sql.MigrationsHistoryTable("__EFMigrationsHistory", "Concesionario"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
