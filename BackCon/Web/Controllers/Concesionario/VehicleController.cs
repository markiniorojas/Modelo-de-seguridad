using Entitys.Models;
using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class VehicleController : GenericController<Vehicle, VehicleRequest, VehicleResponse>
    {
        public VehicleController(IBaseBusiness<Vehicle, VehicleRequest, VehicleResponse> service)
             : base(service) { }
    }
}
