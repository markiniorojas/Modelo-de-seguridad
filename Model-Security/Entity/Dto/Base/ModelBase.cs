using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Base
{
    public class ModelBase
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool is_deleted { get; set; }
    }
}
