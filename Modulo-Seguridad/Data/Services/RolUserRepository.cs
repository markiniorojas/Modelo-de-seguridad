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
    public class RolUserRepository : DataGeneric<RolUser>, IRolUserRepository
    {
        public RolUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<RolUser>> GetAllAsync()
        {
            return await _dbSet
                .Include(u => u.Rol)
                .Include(u => u.User)
                        .Where(u => u.is_deleted == false)
                        .ToListAsync();
        }

        public override async Task<RolUser?> GetByIdAsync(int id)
        {
            return await _dbSet
                      .Include(u => u.Rol)
                      .Include(u => u.User)
                      .Where(u => u.Id == id)
                        .Where(u => u.is_deleted == false)

                      .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<string>> GetJoinRolesAsync(int idUser)
        {
            var rolAsignated = await _dbSet
                               .Include(ru => ru.Rol)
                               .Include(ru => ru.User)
                               .Where(ru => ru.UserId == idUser)
                               .ToListAsync();

            var roles = rolAsignated
                                .Select(ru => ru.Rol.Name)
                                .Where(name => !string.IsNullOrWhiteSpace(name))
                                .Distinct()
                                .ToList();
            return roles;
        }
    }
}
