using Business.Interfaces;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Module
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class PermissionController : BaseController<PermissionDto,Permission,PermissionSelectDto>
    {
        public PermissionController(IBaseBusiness<PermissionDto, Permission, PermissionSelectDto> service) : base(service)
        {
        }
    }
}
