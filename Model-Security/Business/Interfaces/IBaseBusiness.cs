namespace Business.Interfaces
{
    public interface IBaseBusiness<TEntity, TDto, TDtoGet>
    {
        Task<IEnumerable<TDtoGet>> GetAllAsync();
        Task<TDtoGet?> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TDto entity);
        Task<bool> UpdateAsync(TDto entity);
        Task<bool> DeleteAsync(int id);
    }
}
