using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models
{
    public class Seller : GenericModel
    {

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }

        [Range(0, 100)]
        public decimal Commission { get; set; }

        // Relationships
        public ICollection<Sale>? Sales { get; set; }
    }
}
