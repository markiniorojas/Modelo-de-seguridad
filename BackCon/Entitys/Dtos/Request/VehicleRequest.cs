using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Request
{
    public class VehicleRequest
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal SalePrice { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public string? Color { get; set; }
        public int Stock { get; set; }
    }
}
