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

    public class UserController : BaseController<UserDto,User,UserSelectDto>
    {
        public UserController(IBaseBusiness<UserDto, User, UserSelectDto> service) : base(service)
        {
        }
    }
}
