using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Response
{
    public class VehicleSupplierResponse
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string? VehicleModel { get; set; }

        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }

        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
