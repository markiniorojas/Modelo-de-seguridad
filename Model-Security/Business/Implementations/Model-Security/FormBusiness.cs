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
    public class FormBusiness : ABaseBusiness<Form,FormDto, FormSelectDto>, IFormBusiness
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FormBusiness(
           IData<Form> repository,
           ILogger<Form> logger,
           ApplicationDbContext context,
           IMapper mapper)
           : base(repository, logger, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
