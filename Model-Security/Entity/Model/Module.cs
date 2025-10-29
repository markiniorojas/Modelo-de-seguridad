using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Module : BaseModelGeneric
    {
        public List<FormModule> FormModules { get; set; } = new List<FormModule>();
    }
}
