using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Select
{
    public class UserSelectDto : ModelBase
    {
        public string Email { get; set; }
        public string PersonId { get; set; }
        public string PersonName { get; set; }
    }
}
