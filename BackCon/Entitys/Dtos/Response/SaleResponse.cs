using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Response
{
    public class SaleResponse
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }

        public int ClientId { get; set; }
        public string? ClientName { get; set; }

        public int SellerId { get; set; }
        public string? SellerName { get; set; }

        public List<SaleDetailResponse>? Details { get; set; }
    }
}
