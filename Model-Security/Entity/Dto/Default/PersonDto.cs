using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Default
{
    public class PersonDto : ModelBase
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gmail {  get; set; }
        public string Password { get; set; }
    }
}
