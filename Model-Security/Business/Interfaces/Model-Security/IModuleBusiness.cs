using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Model_Security
{
    public interface IModuleBusiness : IBaseBusiness<Module, ModuleDto, ModuleSelectDto>
    {
    }
}
