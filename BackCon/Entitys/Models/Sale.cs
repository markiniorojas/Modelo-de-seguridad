using Entitys.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models
{
    public class Sale : BaseModel
    {
        public DateTime SaleDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public int ClientId { get; set; }

        public int SellerId { get; set; }

        // Relationships
        public Client? Client { get; set; }
        public Seller? Seller { get; set; }
        public ICollection<SaleDetails>? SaleDetails { get; set; }
    }
}
