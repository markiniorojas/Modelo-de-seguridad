using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models
{
    public class Supplier : GenericModel
    {
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string? Contact { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        // Relationships
        public ICollection<VehicleSupplier>? VehicleSuppliers { get; set; }
    }
}
