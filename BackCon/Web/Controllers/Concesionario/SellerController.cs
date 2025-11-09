using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class SellerController : GenericController<Seller, SellerRequest, SellerResponse>
    {
        public SellerController(IBaseBusiness<Seller, SellerRequest, SellerResponse> service)
             : base(service) { }
    }
}
