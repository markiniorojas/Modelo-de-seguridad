using AutoMapper;
using Business.Base;
using Business.Interfaces.Model_Security;
using Data.Interfaces.DataBasic;
using Entity.Context;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Business.Implementations.Model_Security
{
    /// <summary>
    /// Implementación de la lógica de negocio para la entidad Module.
    /// Hereda de ABaseBusiness para reutilizar la lógica CRUD genérica con AutoMapper.
    /// </summary>
    public class ModuleBusiness : ABaseBusiness<Module, ModuleDto, ModuleSelectDto>, IModuleBusiness
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ModuleBusiness(
            IData<Module> repository,
            ILogger<Module> logger,
            ApplicationDbContext context,
            IMapper mapper)
            : base(repository, logger, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
