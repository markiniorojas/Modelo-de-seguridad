using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Context
{
    public static class DbContextFactory
    {
        public static void AddApplicationDbContextFactory(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = configuration["MigrationProvider"]?.ToLower();

            switch (provider)
            {
                case "mysql":
                    services.AddDbContext<MySqlApplicationDbContext>(options =>
                        options.UseMySql(configuration.GetConnectionString("MySql"),
                        ServerVersion.AutoDetect(configuration.GetConnectionString("MySql"))
                        ));
                    break;

                case "postgres":
                case "postgresql":
                    services.AddDbContext<postgreApplicationDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("Postgres")));
                    break;

                default:
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
                    break;
            }
        }
    }
}
