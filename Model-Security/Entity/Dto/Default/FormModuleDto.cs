using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Default
{
    public class FormModuleDto : ModelBase
    {
        public int FormId { get; set; }
        public int ModuleId { get; set; }
    }
}
