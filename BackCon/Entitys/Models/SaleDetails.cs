using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models
{
    public class SaleDetails : BaseModel
    {

        public int SaleId { get; set; }
        public int VehicleId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        public Sale? Sale { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
