using Business.Base;
using Business.Interfaces.Model_Security;
using Data.Interfaces.DataBasic;
using Entity.Context;
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
    public class PermissionBusiness : ABaseBusiness<Permission>, IPermissionBusiness
    {
        private readonly ApplicationDbContext _context;

        public PermissionBusiness(IData<Permission> repository, ILogger<Permission> logger, ApplicationDbContext context)
            : base(repository, logger)
        {
            _context = context;
        }

    }
}
