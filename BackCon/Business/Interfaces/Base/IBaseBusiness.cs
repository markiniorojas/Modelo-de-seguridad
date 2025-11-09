using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Base
{
    public interface IBaseBusiness<TEntity, TDtoRequest, TDtoResponse> where TEntity : BaseModel
    {   
        Task<IEnumerable<TDtoResponse>> GetAllAsync();
        Task<TDtoResponse?> GetByIdAsync(int id);
        Task<TDtoResponse> CreateAsync(TDtoRequest dto);
        Task<bool> UpdateAsync(TDtoRequest dto);
        Task<bool> DeleteAsync(int id);
    }
}
