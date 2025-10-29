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
    public class FormModuleBusiness : ABaseBusiness<FormModule>, IFormModuleBusiness
    {
        private readonly ApplicationDbContext _context;

        public FormModuleBusiness(IData<FormModule> repository, ILogger<FormModule> logger, ApplicationDbContext context)
            : base(repository, logger)
        {
            _context = context;
        }
    }
}
