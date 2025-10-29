using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class FormModule : ModelBase
    {
        public int FormId { get; set; }
        public int ModuleId { get; set; }
        public Form form { get; set; }
        public Module module { get; set; }
    }
}
