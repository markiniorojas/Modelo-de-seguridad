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
    public class FormModuleRepository : DataGeneric<FormModule>, IFormModuleRepository
    {
        public FormModuleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<FormModule>> GetAllAsync()
        {
            return await _dbSet
                        .Include(u => u.form)
                        .Include(u => u.module)
                        .Where(u => u.is_deleted == false)
                        .ToListAsync();
        }

        public override async Task<FormModule?> GetByIdAsync(int id)
        {
            return await _dbSet
                      .Include(u => u.form)
                      .Include(u => u.module)
                      .Where(u => u.Id == id)
                      .FirstOrDefaultAsync();

        }
    }
}
