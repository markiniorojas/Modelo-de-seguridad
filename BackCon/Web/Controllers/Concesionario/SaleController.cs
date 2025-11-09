using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class SaleController : GenericController<Sale, SaleRequest, SaleResponse>
    {
        public SaleController(IBaseBusiness<Sale, SaleRequest, SaleResponse> service)
             : base(service) { }
    }
}
