using Entitys.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.DbContext.Factory
{
    public class SqlServerDbContextFactory : IDbContextFactory
    {
        public ApplicationDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString,
                Sql => Sql.MigrationsHistoryTable("__EFMigrationsHistory", "Concesionario"));
            
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
