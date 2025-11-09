using Business.Interfaces.Base;
using Entitys.Dtos.Request;
using Entitys.Dtos.Response;
using Entitys.Models;
using Web.Controllers.Base;

namespace Web.Controllers.Concesionario
{
    public class ClientController : GenericController<Client, ClientRequest, ClientResponse>
    {
        public ClientController(IBaseBusiness<Client, ClientRequest, ClientResponse> service)
             : base(service) { }
    }
}
