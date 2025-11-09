using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class SaleDetailsController : GenericController<SaleDetails, SaleDetailRequest, SaleDetailResponse>
    {
        public SaleDetailsController(IBaseBusiness<SaleDetails, SaleDetailRequest, SaleDetailResponse> service)
             : base(service) { }
    }
}
