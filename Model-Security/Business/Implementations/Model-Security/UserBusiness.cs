using AutoMapper;
using Business.Base;
//using Business.Implementations.Base;
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
using Utilities.Exceptions;

namespace Business.Implementations.Model_Security
{
    public class UserBusiness : ABaseBusiness<User,UserDto,UserSelectDto>, IUserBusiness
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserBusiness(IData<User> repository, ILogger<User> logger, ApplicationDbContext context, IMapper mapper)
            : base(repository, logger, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
