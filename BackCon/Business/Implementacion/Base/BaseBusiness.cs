using AutoMapper;
using Business.Interfaces.Base;
using Data.Interfaces.Base;
using Entitys.Models.Base;

namespace Business.Implementacion.Base
{
    public class BaseBusiness<TEntity, TDtoRequest, TDtoResponse>
        : IBaseBusiness<TEntity, TDtoRequest, TDtoResponse>
        where TEntity : BaseModel
    {
        private readonly ABaseData<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseBusiness(ABaseData<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDtoResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDtoResponse>>(entities);
        }

        public async Task<TDtoResponse?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDtoResponse>(entity);
        }

        public async Task<TDtoResponse> CreateAsync(TDtoRequest dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<TDtoResponse>(created);
        }

        public async Task<bool> UpdateAsync(TDtoRequest dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
