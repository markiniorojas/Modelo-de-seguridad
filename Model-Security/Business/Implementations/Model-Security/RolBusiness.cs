using AutoMapper;
using Business.Base;
using Business.Interfaces.Model_Security;
using Data.Interfaces.DataBasic;
using Entity.Context;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations.Model_Security
{
    public class RolBusiness : ABaseBusiness<Rol,RolDto,RolSelectDto>, IRolBusiness
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RolBusiness(IData<Rol> repository, ILogger<Rol> logger, ApplicationDbContext context, IMapper mapper)
            : base(repository, logger, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
