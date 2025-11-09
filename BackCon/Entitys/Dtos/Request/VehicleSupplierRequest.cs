using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Request
{
    public class VehicleSupplierRequest
    {
        public int VehicleId { get; set; }
        public int SupplierId { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
