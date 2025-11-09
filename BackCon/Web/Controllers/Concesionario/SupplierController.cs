using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class SupplierController : GenericController<Supplier, SupplierRequest, SupplierResponse>
    {
        public SupplierController(IBaseBusiness<Supplier, SupplierRequest, SupplierResponse> service)
             : base(service) { }
    }
}
