using AutoMapper;
using Business.Interfaces;
using Data.Interfaces.DataBasic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Business.Base
{
    public abstract class ABaseBusiness<TEntity, TDto, TDtoGet> : IBaseBusiness<TEntity, TDto, TDtoGet>
        where TEntity : class
        where TDto : class
        where TDtoGet : class
    {
        protected readonly IData<TEntity> _repository;
        protected readonly ILogger<TEntity> _logger;
        protected readonly IMapper _mapper;

        protected ABaseBusiness(IData<TEntity> repository, ILogger<TEntity> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDtoGet>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<TDtoGet>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener registros de {Entity}", typeof(TEntity).Name);
                throw new BusinessException($"Error al obtener registros de {typeof(TEntity).Name}", ex);
            }
        }

        public virtual async Task<TDtoGet?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(TEntity).Name, id);

                return _mapper.Map<TDtoGet>(entity);
            }
            catch (EntityNotFoundException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener {Entity} con ID {Id}", typeof(TEntity).Name, id);
                throw new BusinessException($"Error al obtener {typeof(TEntity).Name} con ID {id}", ex);
            }
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                var created = await _repository.CreateAsync(entity);
                return _mapper.Map<TDto>(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear {Entity}", typeof(TEntity).Name);
                throw new BusinessException($"Error al crear {typeof(TEntity).Name}", ex);
            }
        }

        public virtual async Task<bool> UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar {Entity}", typeof(TEntity).Name);
                throw new BusinessException($"Error al actualizar {typeof(TEntity).Name}", ex);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                if (!result)
                    throw new EntityNotFoundException(typeof(TEntity).Name, id);
                return result;
            }
            catch (EntityNotFoundException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar {Entity} con ID {Id}", typeof(TEntity).Name, id);
                throw new BusinessException($"Error al eliminar {typeof(TEntity).Name} con ID {id}", ex);
            }
        }
    }
}
