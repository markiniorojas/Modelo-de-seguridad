using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models
{
    public class Vehicle : BaseModel
    {
        [Required, MaxLength(50)]
        public string Brand { get; set; }

        [Required, MaxLength(50)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        [Required, MaxLength(30)]
        public string FuelType { get; set; }

        [MaxLength(20)]
        public string? Color { get; set; }

        public int Stock { get; set; }

        // Relationships
        public ICollection<SaleDetails>? SaleDetails { get; set; }
        public ICollection<VehicleSupplier>? VehicleSuppliers { get; set; }
    }
}
