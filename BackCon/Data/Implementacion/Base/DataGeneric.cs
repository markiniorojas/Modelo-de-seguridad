using Data.Interfaces.Base;
using Entitys.Context;
using Entitys.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementacion.Base
{
    public class DataGeneric<T> : ABaseData<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public DataGeneric(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Obtener todos los registros no eliminados
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .Where(x => !x.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        // Obtener por ID
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return null;

            return entity;
        }

        // Crear nuevo registro
        public virtual async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Actualizar registro existente
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            var existing = await _dbSet.FindAsync(entity.Id);
            if (existing == null || existing.IsDeleted)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminación lógica (soft delete)
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
