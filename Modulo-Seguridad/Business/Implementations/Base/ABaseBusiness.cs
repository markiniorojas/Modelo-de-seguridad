using Business.Interfaces;
using Data.Interfaces.DataBasic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Business.Base
{
    /// <summary>
    /// Clase base genérica para la capa Business.
    /// Implementa operaciones CRUD y manejo de excepciones.
    /// </summary>
    public abstract class ABaseBusiness<T> : IBaseBusiness<T> where T : class
    {
        protected readonly IData<T> _repository;
        protected readonly ILogger<T> _logger;

        protected ABaseBusiness(IData<T> repository, ILogger<T> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener registros de {Entity}", typeof(T).Name);
                throw new BusinessException($"Error al obtener registros de {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(T).Name, id);
                return entity;
            }
            catch (EntityNotFoundException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener {Entity} con ID {Id}", typeof(T).Name, id);
                throw new BusinessException($"Error al obtener {typeof(T).Name} con ID {id}", ex);
            }
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            try
            {
                return await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear {Entity}", typeof(T).Name);
                throw new BusinessException($"Error al crear {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar {Entity}", typeof(T).Name);
                throw new BusinessException($"Error al actualizar {typeof(T).Name}", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                if (!result)
                    throw new EntityNotFoundException(typeof(T).Name, id);
                return result;
            }
            catch (EntityNotFoundException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar {Entity} con ID {Id}", typeof(T).Name, id);
                throw new BusinessException($"Error al eliminar {typeof(T).Name} con ID {id}", ex);
            }
        }
    }
}
