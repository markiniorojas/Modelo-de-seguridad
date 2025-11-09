using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class VehicleSupplierController : GenericController<VehicleSupplier, VehicleSupplierRequest, VehicleSupplierResponse>
    {
        public VehicleSupplierController(IBaseBusiness<VehicleSupplier, VehicleSupplierRequest, VehicleSupplierResponse> service) : base(service) { }
    }
}
