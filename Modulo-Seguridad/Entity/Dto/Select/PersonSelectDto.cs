using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Select
{
    public class PersonSelectDto : ModelBase
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gmail { get; set; }
    }
}
