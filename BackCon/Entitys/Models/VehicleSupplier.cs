using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models
{
    public class VehicleSupplier : BaseModel
    {
        public int VehicleId { get; set; }
        public int SupplierId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        // Relationships
        public Vehicle? Vehicle { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
