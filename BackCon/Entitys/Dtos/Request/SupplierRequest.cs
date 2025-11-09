using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Request
{
    public class SupplierRequest
    {
        public string CompanyName { get; set; } = string.Empty;
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
