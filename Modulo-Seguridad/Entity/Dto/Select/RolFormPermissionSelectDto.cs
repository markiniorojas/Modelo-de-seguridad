
using Entity.Dto.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Select
{
    public class RolFormPermissionSelectDto : ModelBase
    {
        public int RolId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }
        public string RolName { get; set; }
        public string FormName { get; set; }
        public string PermissionName { get; set; }
    }
}
