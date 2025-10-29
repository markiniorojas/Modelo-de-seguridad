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

    public class RolUserController : BaseController<RolUserDto>
    {
        public RolUserController(IBaseBusiness<RolUserDto> service) : base(service)
        {
        }
    }
}
