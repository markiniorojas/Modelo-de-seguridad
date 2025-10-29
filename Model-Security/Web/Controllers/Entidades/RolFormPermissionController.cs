using Business.Interfaces;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class RolFormPermissionController : BaseController<RolFormPermissionDto,RolFormPermissionDto,RolFormPermissionSelectDto>
    {
        public RolFormPermissionController(IBaseBusiness<RolFormPermissionDto, RolFormPermissionDto, RolFormPermissionSelectDto> service) : base(service)
        {
        }
    }
}
