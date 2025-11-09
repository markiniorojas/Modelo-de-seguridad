using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Request
{
    public class SaleRequest
    {
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }
        public int SellerId { get; set; }

        public List<SaleDetailRequest>? Details { get; set; }
    }
}
