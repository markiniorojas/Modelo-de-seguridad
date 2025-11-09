using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Response
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal SalePrice { get; set; }
        public string FuelType { get; set; }
        public string? Color { get; set; }
        public int Stock { get; set; }
    }
}
