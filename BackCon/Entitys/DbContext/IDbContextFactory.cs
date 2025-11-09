using Entitys.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Context
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext(string connectionString);
    }
}
