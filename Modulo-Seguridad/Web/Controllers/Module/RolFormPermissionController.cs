using Business.Interfaces;
using Entity.Dto.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class RolFormPermissionController : BaseController<RolFormPermissionDto>
    {
        public RolFormPermissionController(IBaseBusiness<RolFormPermissionDto> service) : base(service)
        {
        }
    }
}
