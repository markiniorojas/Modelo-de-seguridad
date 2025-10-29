using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Select
{
    public class FormModuleSelectDto : ModelBase
    {
        public int FormId { get; set; }
        public int ModuleId { get; set; }

        public string FormName { get; set; }
        public string ModuleName { get; set; }
    }
}
