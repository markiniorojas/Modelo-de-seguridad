using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class User : ModelBase
    {
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
        public List<RolFormPermission> rol_form_permission { get; set; } = new List<RolFormPermission>();

        public List<FormModule> FormModules { get; set; } = new List<FormModule>();
    }
}
