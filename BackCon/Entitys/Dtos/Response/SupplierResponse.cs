using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Response
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public List<VehicleResponse>? Vehicles { get; set; }
    }
}
