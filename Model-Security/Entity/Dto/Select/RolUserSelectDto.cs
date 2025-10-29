using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Select
{
    public class RolUserSelectDto : ModelBase
    {
        public int RolId { get; set; }
        public int UserId { get; set; }
        public string RolName { get; set; }
        public string UserName { get; set; }
    }
}
