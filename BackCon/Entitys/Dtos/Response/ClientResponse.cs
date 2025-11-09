using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Dtos.Response
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public List<SaleResponse>? Sales { get; set; }
    }
}
