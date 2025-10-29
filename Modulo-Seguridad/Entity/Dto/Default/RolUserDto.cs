using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Default
{
    public class RolUserDto : ModelBase
    {
        public int RolId { get; set; }
        public int UserId { get; set; }
    }
}
