
using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Default
{
    public class RolFormPermissionDto : ModelBase
    {
        public int RolId { get; set; }
        public int FormId { get; set; }
        public int PermissionId {  get; set; }
    }
}
