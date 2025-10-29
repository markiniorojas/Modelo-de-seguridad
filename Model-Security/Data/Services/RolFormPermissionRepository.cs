using Data.Interfaces.DataImplement;
using Data.Repository;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class RolFormPermissionRepository : DataGeneric<RolFormPermission>, IRolFormPermissionRepository
    {
        public RolFormPermissionRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<RolFormPermission>> GetAllAsync()
        {
            return await _dbSet
                        .Include(u => u.Rol)
                        .Include(u => u.Form)
                        .Include(u => u.Permission)
                        .Where(u => u.is_deleted == false)

                        .ToListAsync();
        }

        public override async Task<RolFormPermission?> GetByIdAsync(int id)
        {
            return await _dbSet
                      .Include(u => u.Rol)
                      .Include(u => u.Form)
                      .Include(u => u.Permission)
                      .Where(u => u.Id == id)
                      .FirstOrDefaultAsync();

        }
    }
}
