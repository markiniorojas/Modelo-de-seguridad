using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Response
{
    public class SaleDetailResponse
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
